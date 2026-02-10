using DALTripster.Data.Seeds;
using DALTripster.Entities;
using DATripster.Data.Seeds;
using DATripster.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATripster.Data
{
    public class TripsterDB : IdentityDbContext<ApplicationUser>
    {
        public TripsterDB(DbContextOptions<TripsterDB> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; } = default!;
        public DbSet<Room> Rooms { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;
        public DbSet<Image> Images { get; set; } = default!;
        public DbSet<Service> Services { get; set; } = default!;
        public DbSet<HotelService> HotelServices { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelService>()
                .HasKey(hs => new { hs.HotelId, hs.ServiceId });

            modelBuilder.Entity<HotelService>()
                .HasOne(hs => hs.Hotel)
                .WithMany(h => h.HotelServices)
                .HasForeignKey(hs => hs.HotelId);

            modelBuilder.Entity<HotelService>()
                .HasOne(hs => hs.Service)
                .WithMany(s => s.HotelServices)
                .HasForeignKey(hs => hs.ServiceId);
            modelBuilder.Entity<HotelService>()
           .ToTable("HotelServices");
            base.OnModelCreating(modelBuilder);

            //Seed data for Hotel, Room, User, Booking, Review, Image, Service, and HotelService entities
            //base.OnModelCreating(modelBuilder);

            //HotelSeed.Seed(modelBuilder);
            //RoomSeed.Seed(modelBuilder);
            //ImageSeed.Seed(modelBuilder);
            //UserSeed.Seed(modelBuilder);
            //ServiceSeed.Seed(modelBuilder);
            //HotelServiceSeed.Seed(modelBuilder);
            //ReviewSeed.Seed(modelBuilder);
            //BookingSeed.Seed(modelBuilder);

            // ... (rest of your seeding code remains unchanged)
        }
    }
}
