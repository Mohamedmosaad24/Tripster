using BLTripster.IServices;
using BLTripster.Services;
using DALTripster.IRepos;
using DALTripster.Repos;
using DATripster.Data;
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
            builder.Services.AddScoped<ISearchService, SearchService>();
            builder.Services.AddScoped<ISearchRepo, SearchRepo>();
            builder.Services.AddDbContext<TripsterDB>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
