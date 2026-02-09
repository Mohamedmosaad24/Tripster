using BLTripster.IServices;
using BLTripster.Services;
using DALTripster.Entities;
using DALTripster.IRepos;
using DALTripster.Repos;
using DATripster.Data;
using DATripster.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PLTripster
{
    public class Program
    {
        public static void Main(string[] args)
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

            builder.Services.AddDbContext<TripsterDB>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TripsterDB>();

            var app = builder.Build();

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

            app.Run();
        }
    }
}
