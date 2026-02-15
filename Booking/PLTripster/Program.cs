using BLTripster.IServices;
using BLTripster.Services;
using DALTripster.Entities;
using DALTripster.IRepos;
using DALTripster.Repos;
using DATripster.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PLTripster
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IHomeRepo, HomeRepo>();
            builder.Services.AddScoped<IHomeService, HomeService>();
            builder.Services.AddScoped<ISearchService, SearchService>();
            builder.Services.AddScoped<ISearchRepo, SearchRepo>();
            builder.Services.AddScoped<IHotelRepo, HotelRepo>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IReviewRepo, ReviewRepo>();
            builder.Services.AddScoped<IReviewService, ReviewServices>();
            builder.Services.AddDbContext<TripsterDB>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TripsterDB>();

            var app = builder.Build();

            // When app is hosted under a path (e.g. http://localhost:55000/Booking/), set PathBase so links work
            var pathBase = builder.Configuration["PathBase"];
            if (!string.IsNullOrEmpty(pathBase))
            {
                app.UsePathBase(pathBase);
            }

            // Ensure AspNetUsers has FullName column (fixes "Invalid column name 'FullName'" after sign up/sign in)
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TripsterDB>();
                try
                {
                    db.Database.ExecuteSqlRaw(
                        "IF NOT EXISTS (SELECT 1 FROM sys.columns c INNER JOIN sys.tables t ON c.object_id = t.object_id WHERE t.name = 'AspNetUsers' AND c.name = 'FullName') " +
                        "ALTER TABLE AspNetUsers ADD FullName nvarchar(max) NOT NULL DEFAULT N''");
                }
                catch { /* column may already exist or DB not ready */ }

                // Fix broken image URLs in existing database
                try
                {
                    // Fix user images that point to example.com or have no image
                    var users = db.Users.ToList();
                    var userImages = new[] { "/assets/hotelImg/hotel1.jpg", "/assets/hotelImg/hotel3.jpg", "/assets/hotelImg/hotel4.jpg", "/assets/hotelImg/hotel6.jpg", "/assets/hotelImg/hotel8.jpg" };
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (string.IsNullOrEmpty(users[i].ImageUrl) || users[i].ImageUrl.Contains("example.com") || users[i].ImageUrl.StartsWith("http"))
                        {
                            users[i].ImageUrl = userImages[i % userImages.Length];
                        }
                    }

                    // Fix hotel images: replace broken URLs & ensure each hotel has images
                    var hotelImages = db.Images.Where(img => img.HotelId != null).ToList();
                    var brokenHotelImages = hotelImages.Where(img => 
                        string.IsNullOrEmpty(img.ImageUrl) || img.ImageUrl.Contains("example.com") || 
                        (img.ImageUrl.StartsWith("http") && !img.ImageUrl.StartsWith("/"))).ToList();
                    
                    var hotelImgPool = new[] { "/assets/hotelImg/hotel1.jpg", "/assets/hotelImg/hotel3.jpg", "/assets/hotelImg/hotel4.jpg", "/assets/hotelImg/hotel6.jpg", "/assets/hotelImg/hotel7.jpg", "/assets/hotelImg/hotel8.jpg", "/assets/hotelImg/hotel9.jpg", "/assets/hotelImg/hotel10.jpg", "/assets/hotelImg/hotel11.jpg", "/assets/hotelImg/hotel12.jpg" };
                    int imgIdx = 0;
                    foreach (var img in brokenHotelImages)
                    {
                        img.ImageUrl = hotelImgPool[imgIdx % hotelImgPool.Length];
                        imgIdx++;
                    }

                    // Ensure every hotel has at least 5 images
                    var hotelIds = db.Set<DATripster.Entities.Hotel>().Select(h => h.Id).ToList();
                    foreach (var hotelId in hotelIds)
                    {
                        var existingCount = db.Images.Count(img => img.HotelId == hotelId && img.RoomId == null);
                        for (int i = existingCount; i < 5; i++)
                        {
                            db.Images.Add(new DATripster.Entities.Image
                            {
                                ImageUrl = hotelImgPool[(hotelId * 5 + i) % hotelImgPool.Length],
                                HotelId = hotelId,
                                RoomId = null
                            });
                        }
                    }

                    // Fix room images: replace broken URLs & ensure each room has an image
                    var roomImgPool = new[] { "/assets/roomImg/room-1.jpg", "/assets/roomImg/room-2.jpg", "/assets/roomImg/room-3.jpg", "/assets/roomImg/room-4.jpg", "/assets/roomImg/room-5.jpg", "/assets/roomImg/room-6.jpg", "/assets/roomImg/room-7.jpg" };
                    var roomImages = db.Images.Where(img => img.RoomId != null).ToList();
                    var brokenRoomImages = roomImages.Where(img =>
                        string.IsNullOrEmpty(img.ImageUrl) || img.ImageUrl.Contains("example.com") ||
                        (img.ImageUrl.StartsWith("http") && !img.ImageUrl.StartsWith("/"))).ToList();
                    int rIdx = 0;
                    foreach (var img in brokenRoomImages)
                    {
                        img.ImageUrl = roomImgPool[rIdx % roomImgPool.Length];
                        rIdx++;
                    }

                    // Ensure every room has at least 1 image
                    var rooms = db.Rooms.Include(r => r.Images).ToList();
                    foreach (var room in rooms)
                    {
                        if (room.Images == null || !room.Images.Any())
                        {
                            db.Images.Add(new DATripster.Entities.Image
                            {
                                ImageUrl = roomImgPool[room.Id % roomImgPool.Length],
                                HotelId = room.HotelId,
                                RoomId = room.Id
                            });
                        }
                    }

                    db.SaveChanges();
                }
                catch { /* Images table may not exist yet */ }
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Seed Admin role and default admin user
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                // Create Admin role if it doesn't exist
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                // Create default admin user if it doesn't exist
                var adminEmail = "admin@tripster.com";
                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    adminUser = new ApplicationUser
                    {
                        UserName = "admin",
                        Email = adminEmail,
                        FullName = "Admin",
                        EmailConfirmed = true
                    };
                    var result = await userManager.CreateAsync(adminUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }
                else if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            app.Run();
        }
    }
}
