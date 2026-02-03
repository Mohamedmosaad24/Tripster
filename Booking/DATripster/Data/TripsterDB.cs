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

            base.OnModelCreating(modelBuilder);









            // ═══════════════════════════════════════════════════════
            // Seed Data - Users
            // ═══════════════════════════════════════════════════════
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "john@gmail.com",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    ImageUrl = "https://picsum.photos/id/1005/400/400",
                    Location = "New York",
                    Nationality = "American"
                },
                new User
                {
                    Id = 2,
                    Name = "Sara Ali",
                    Email = "sara.ali@gmail.com",
                    DateOfBirth = new DateTime(1996, 5, 14),
                    ImageUrl = "https://picsum.photos/id/1027/400/400",
                    Location = "Cairo",
                    Nationality = "Egyptian"
                },
                new User
                {
                    Id = 3,
                    Name = "Omar Hassan",
                    Email = "omar.hassan@gmail.com",
                    DateOfBirth = new DateTime(1993, 11, 20),
                    ImageUrl = "https://picsum.photos/id/1011/400/400",
                    Location = "Alexandria",
                    Nationality = "Egyptian"
                }
            );

            // ═══════════════════════════════════════════════════════
            // Seed Data - Hotels
            // ═══════════════════════════════════════════════════════
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Sunrise Hotel",
                    Latitude = 29.9773,
                    Longitude = 31.1325,
                    Address = "12 Nile Street, Giza",
                    Description = "Family-friendly hotel near major attractions."
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Sea Breeze Resort",
                    Latitude = 27.2579,
                    Longitude = 33.8116,
                    Address = "88 Marina Road, Hurghada",
                    Description = "Beach resort with sea view rooms and water activities."
                }
            );

            // ═══════════════════════════════════════════════════════
            // Seed Data - Rooms
            // ═══════════════════════════════════════════════════════
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    RoomType = "Single",
                    Capacity = 1,
                    Price = 60.0m,
                    IsAvailable = true,
                    HotelId = 1
                },
                new Room
                {
                    Id = 2,
                    RoomType = "Double",
                    Capacity = 2,
                    Price = 95.0m,
                    IsAvailable = true,
                    HotelId = 1
                },
                new Room
                {
                    Id = 3,
                    RoomType = "Suite",
                    Capacity = 4,
                    Price = 180.0m,
                    IsAvailable = true,
                    HotelId = 2
                },
                new Room
                {
                    Id = 4,
                    RoomType = "Double",
                    Capacity = 2,
                    Price = 110.0m,
                    IsAvailable = false,
                    HotelId = 2
                }
            );

            // ═══════════════════════════════════════════════════════
            // Seed Data - Bookings
            // ═══════════════════════════════════════════════════════
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    CheckIn = new DateTime(2026, 2, 5),
                    CheckOut = new DateTime(2026, 2, 8),
                    TotalPrice = 285.0m,
                    RoomId = 2,
                    UserId = 1
                },
                new Booking
                {
                    Id = 2,
                    CheckIn = new DateTime(2026, 3, 1),
                    CheckOut = new DateTime(2026, 3, 6),
                    TotalPrice = 900.0m,
                    RoomId = 3,
                    UserId = 2
                },
                new Booking
                {
                    Id = 3,
                    CheckIn = new DateTime(2026, 2, 10),
                    CheckOut = new DateTime(2026, 2, 12),
                    TotalPrice = 120.0m,
                    RoomId = 1,
                    UserId = 3
                }
            );

            // ═══════════════════════════════════════════════════════
            // Seed Data - Reviews
            // ═══════════════════════════════════════════════════════
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    Rate = 5,
                    Comment = "Very clean and great service.",
                    HotelId = 1,
                    UserId = 1
                },
                new Review
                {
                    Id = 2,
                    Rate = 4,
                    Comment = "Amazing beach view, would visit again!",
                    HotelId = 2,
                    UserId = 2
                },
                new Review
                {
                    Id = 3,
                    Rate = 3,
                    Comment = "Good for the price, but room was small.",
                    HotelId = 1,
                    UserId = 3
                }
            );

            // ═══════════════════════════════════════════════════════
            // Seed Data - Services
            // ═══════════════════════════════════════════════════════
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Free Wi-Fi" },
                new Service { Id = 2, Name = "Breakfast Included" },
                new Service { Id = 3, Name = "Swimming Pool" },
                new Service { Id = 4, Name = "Airport Pickup" },
                new Service { Id = 5, Name = "Gym" }
            );

            // ═══════════════════════════════════════════════════════
            // Seed Data - HotelServices (Many-to-Many)
            // ═══════════════════════════════════════════════════════
            modelBuilder.Entity<HotelService>().HasData(
                new HotelService { HotelId = 1, ServiceId = 1 },
                new HotelService { HotelId = 1, ServiceId = 2 },
                new HotelService { HotelId = 1, ServiceId = 4 },
                new HotelService { HotelId = 2, ServiceId = 1 },
                new HotelService { HotelId = 2, ServiceId = 2 },
                new HotelService { HotelId = 2, ServiceId = 3 },
                new HotelService { HotelId = 2, ServiceId = 5 }
            );

            // ═══════════════════════════════════════════════════════
            // Seed Data - Images
            // ═══════════════════════════════════════════════════════
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = 1,
                    ImageUrl = "https://picsum.photos/id/1018/900/600",
                    HotelId = 1,
                    RoomId = null
                },
                new Image
                {
                    Id = 2,
                    ImageUrl = "https://picsum.photos/id/1019/900/600",
                    HotelId = null,
                    RoomId = 2
                },
                new Image
                {
                    Id = 3,
                    ImageUrl = "https://picsum.photos/id/1020/900/600",
                    HotelId = null,
                    RoomId = 3
                },
                new Image
                {
                    Id = 4,
                    ImageUrl = "https://picsum.photos/id/1021/900/600",
                    HotelId = null,
                    RoomId = 4
                }
            );

        }



    }
}
