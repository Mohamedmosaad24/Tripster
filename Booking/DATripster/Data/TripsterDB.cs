using DATripster.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATripster.Data
{
    public class TripsterDB : DbContext
    {
        public TripsterDB(DbContextOptions<TripsterDB> options) : base(options)
        {
        }
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

            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Hotel> Hotels { get; set; } = default!;
        public DbSet<Room> Rooms { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;
        public DbSet<Image> Images { get; set; } = default!;
        public DbSet<Service> Services { get; set; } = default!;
        public DbSet<HotelService> HotelServices { get; set; } = default!;


    }
}
