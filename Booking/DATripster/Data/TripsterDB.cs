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


            // ============================================
            // SEED DATA
            // ============================================

            #region Users Seed Data
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Ahmed Mohamed Ali",
                    Location = "Cairo, Egypt",
                    Email = "ahmed.mohamed@email.com",
                    Nationality = "Egyptian",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    ImageUrl = "https://example.com/images/users/ahmed.jpg"
                },
                new User
                {
                    Id = 2,
                    Name = "Fatima Hassan",
                    Location = "Alexandria, Egypt",
                    Email = "fatima.hassan@email.com",
                    Nationality = "Egyptian",
                    DateOfBirth = new DateTime(1988, 8, 22),
                    ImageUrl = "https://example.com/images/users/fatima.jpg"
                },
                new User
                {
                    Id = 3,
                    Name = "Mahmoud Abdullah",
                    Location = "Giza, Egypt",
                    Email = "mahmoud.abdullah@email.com",
                    Nationality = "Egyptian",
                    DateOfBirth = new DateTime(1992, 3, 10),
                    ImageUrl = "https://example.com/images/users/mahmoud.jpg"
                },
                new User
                {
                    Id = 4,
                    Name = "Nour Al-Din",
                    Location = "Dubai, UAE",
                    Email = "nour.aldeen@email.com",
                    Nationality = "Emirati",
                    DateOfBirth = new DateTime(1985, 12, 5),
                    ImageUrl = "https://example.com/images/users/nour.jpg"
                },
                new User
                {
                    Id = 5,
                    Name = "Sara Ahmed",
                    Location = "Riyadh, Saudi Arabia",
                    Email = "sara.ahmed@email.com",
                    Nationality = "Saudi",
                    DateOfBirth = new DateTime(1995, 7, 18),
                    ImageUrl = "https://example.com/images/users/sara.jpg"
                }
            );
            #endregion

            #region Hotels Seed Data
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Golden Nile Hotel",
                    Latitude = 30.0444,
                    Longitude = 31.2357,
                    Address = "Nile Corniche, Cairo, Egypt",
                    Description = "Luxury 5-star hotel overlooking the Nile River with stunning views and world-class facilities"
                },
                new Hotel
                {
                    Id = 2,
                    Name = "North Coast Resort",
                    Latitude = 30.8913,
                    Longitude = 29.7434,
                    Address = "KM 120, North Coast, Egypt",
                    Description = "Elegant beachfront resort on the Mediterranean Sea offering an unforgettable relaxation experience"
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Royal Pyramids Hotel",
                    Latitude = 29.9792,
                    Longitude = 31.1342,
                    Address = "Pyramid Street, Giza, Egypt",
                    Description = "Historic hotel near the Pyramids combining authenticity with modern comfort"
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Red Sea Resort",
                    Latitude = 27.2579,
                    Longitude = 33.8116,
                    Address = "Tourist Promenade, Sharm El Sheikh, Egypt",
                    Description = "World-class diving resort on the Red Sea with spectacular coral reefs"
                },
                new Hotel
                {
                    Id = 5,
                    Name = "Alexandria Palace",
                    Latitude = 31.2001,
                    Longitude = 29.9187,
                    Address = "Alexandria Corniche, Alexandria, Egypt",
                    Description = "Luxury boutique hotel on the Mediterranean coast with rich historical heritage"
                }
            );
            #endregion

            #region Services Seed Data
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Free WiFi" },
                new Service { Id = 2, Name = "Outdoor Pool" },
                new Service { Id = 3, Name = "Spa & Wellness Center" },
                new Service { Id = 4, Name = "Fitness Center" },
                new Service { Id = 5, Name = "Fine Dining Restaurant" }
            );
            #endregion

            #region HotelServices Seed Data
            modelBuilder.Entity<HotelService>().HasData(
                // Golden Nile Hotel services
                new HotelService { HotelId = 1, ServiceId = 1 },
                new HotelService { HotelId = 1, ServiceId = 2 },
                new HotelService { HotelId = 1, ServiceId = 3 },
                new HotelService { HotelId = 1, ServiceId = 4 },
                new HotelService { HotelId = 1, ServiceId = 5 },

                // North Coast Resort services
                new HotelService { HotelId = 2, ServiceId = 1 },
                new HotelService { HotelId = 2, ServiceId = 2 },
                new HotelService { HotelId = 2, ServiceId = 3 },
                new HotelService { HotelId = 2, ServiceId = 5 },

                // Royal Pyramids Hotel services
                new HotelService { HotelId = 3, ServiceId = 1 },
                new HotelService { HotelId = 3, ServiceId = 2 },
                new HotelService { HotelId = 3, ServiceId = 4 },
                new HotelService { HotelId = 3, ServiceId = 5 },

                // Red Sea Resort services
                new HotelService { HotelId = 4, ServiceId = 1 },
                new HotelService { HotelId = 4, ServiceId = 2 },
                new HotelService { HotelId = 4, ServiceId = 3 },

                // Alexandria Palace services
                new HotelService { HotelId = 5, ServiceId = 1 },
                new HotelService { HotelId = 5, ServiceId = 3 },
                new HotelService { HotelId = 5, ServiceId = 5 }
            );
            #endregion

            #region Rooms Seed Data
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    RoomType = "Royal Suite",
                    Capacity = 4,
                    Price = 3500.00m,
                    IsAvailable = true,
                    Sqm = 85.5f,
                    NumberOFBathRoom = 2,
                    TypeOfBed = TypeOfBed.King,
                    HotelId = 1
                },
                new Room
                {
                    Id = 2,
                    RoomType = "Deluxe Nile View Room",
                    Capacity = 2,
                    Price = 2200.00m,
                    IsAvailable = true,
                    Sqm = 45.0f,
                    NumberOFBathRoom = 1,
                    TypeOfBed = TypeOfBed.King,
                    HotelId = 1
                },
                new Room
                {
                    Id = 3,
                    RoomType = "Beach Front Chalet",
                    Capacity = 4,
                    Price = 3200.00m,
                    IsAvailable = true,
                    Sqm = 75.0f,
                    NumberOFBathRoom = 2,
                    TypeOfBed = TypeOfBed.King,
                    HotelId = 2
                },
                new Room
                {
                    Id = 4,
                    RoomType = "Pyramid View Room",
                    Capacity = 2,
                    Price = 2500.00m,
                    IsAvailable = true,
                    Sqm = 50.0f,
                    NumberOFBathRoom = 1,
                    TypeOfBed = TypeOfBed.Queen,
                    HotelId = 3
                },
                new Room
                {
                    Id = 5,
                    RoomType = "Divers Room",
                    Capacity = 2,
                    Price = 1900.00m,
                    IsAvailable = true,
                    Sqm = 40.0f,
                    NumberOFBathRoom = 1,
                    TypeOfBed = TypeOfBed.Queen,
                    HotelId = 4
                }
            );
            #endregion

            #region Bookings Seed Data
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    CheckIn = new DateTime(2025, 12, 15),
                    CheckOut = new DateTime(2025, 12, 20),
                    TotalPrice = 11000.00m,
                    RoomId = 1,
                    UserId = 1
                },
                new Booking
                {
                    Id = 2,
                    CheckIn = new DateTime(2026, 1, 5),
                    CheckOut = new DateTime(2026, 1, 10),
                    TotalPrice = 11000.00m,
                    RoomId = 2,
                    UserId = 2
                },
                new Booking
                {
                    Id = 3,
                    CheckIn = new DateTime(2026, 2, 20),
                    CheckOut = new DateTime(2026, 2, 25),
                    TotalPrice = 16000.00m,
                    RoomId = 3,
                    UserId = 3
                },
                new Booking
                {
                    Id = 4,
                    CheckIn = new DateTime(2026, 3, 1),
                    CheckOut = new DateTime(2026, 3, 7),
                    TotalPrice = 15000.00m,
                    RoomId = 4,
                    UserId = 4
                },
                new Booking
                {
                    Id = 5,
                    CheckIn = new DateTime(2026, 3, 15),
                    CheckOut = new DateTime(2026, 3, 20),
                    TotalPrice = 9500.00m,
                    RoomId = 5,
                    UserId = 5
                }
            );
            #endregion

            #region Reviews Seed Data
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    Rate = 5,
                    Comment = "Excellent hotel! Outstanding service and the Nile view is fantastic. Highly recommended.",
                    HotelId = 1,
                    UserId = 1
                },
                new Review
                {
                    Id = 2,
                    Rate = 4,
                    Comment = "Good hotel with excellent location. Rooms are clean but breakfast needs improvement.",
                    HotelId = 1,
                    UserId = 2
                },
                new Review
                {
                    Id = 3,
                    Rate = 5,
                    Comment = "Amazing beach resort! Clean beach and modern facilities. Unforgettable experience.",
                    HotelId = 2,
                    UserId = 3
                },
                new Review
                {
                    Id = 4,
                    Rate = 5,
                    Comment = "Perfect location next to the Pyramids. Historic and luxurious hotel. Exceptional service.",
                    HotelId = 3,
                    UserId = 4
                },
                new Review
                {
                    Id = 5,
                    Rate = 4,
                    Comment = "Great hotel for diving. Excellent facilities but rooms need renovation.",
                    HotelId = 4,
                    UserId = 5
                }
            );
            #endregion

            #region Images Seed Data
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = 1,
                    ImageUrl = "https://example.com/hotels/golden-nile/exterior.jpg",
                    HotelId = 1,
                    RoomId = null
                },
                new Image
                {
                    Id = 2,
                    ImageUrl = "https://example.com/hotels/golden-nile/royal-suite.jpg",
                    HotelId = 1,
                    RoomId = 1
                },
                new Image
                {
                    Id = 3,
                    ImageUrl = "https://example.com/hotels/north-coast/beach-view.jpg",
                    HotelId = 2,
                    RoomId = null
                },
                new Image
                {
                    Id = 4,
                    ImageUrl = "https://example.com/hotels/pyramids/pyramid-view.jpg",
                    HotelId = 3,
                    RoomId = null
                },
                new Image
                {
                    Id = 5,
                    ImageUrl = "https://example.com/hotels/red-sea/diving-center.jpg",
                    HotelId = 4,
                    RoomId = null
                }
            );
            #endregion
        }
    }
}
