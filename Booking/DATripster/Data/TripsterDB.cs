using DALTripster.Entities;
using DATripster.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DATripster.Data
{
    public class TripsterDB : IdentityDbContext<ApplicationUser>
    {
        public TripsterDB(DbContextOptions<TripsterDB> options) : base(options) { }

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
            // Configure Many-to-Many for HotelService
            modelBuilder.Entity<HotelService>().HasKey(hs => new { hs.HotelId, hs.ServiceId });
            modelBuilder.Entity<HotelService>().ToTable("HotelServices");

            // Decimal precision for financial fields
            modelBuilder.Entity<Room>().Property(r => r.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Booking>().Property(b => b.TotalPrice).HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
            //////////////////////
            modelBuilder.Entity<Room>()
        .HasOne(r => r.Hotel)
        .WithMany(h => h.Rooms)
        .HasForeignKey(r => r.HotelId)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Hotel)
                .WithMany(h => h.Images)
                .HasForeignKey(i => i.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Reviews)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HotelService>()
                .HasOne(hs => hs.Hotel)
                .WithMany(h => h.HotelServices)
                .HasForeignKey(hs => hs.HotelId)
                .OnDelete(DeleteBehavior.Cascade);
            // ============================================
            // SEED DATA (Cleaned & Organized)
            // ============================================

            #region Users Seed
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Ahmed Mohamed", Email = "ahmed@email.com", Location = "Cairo", Nationality = "Egyptian", DateOfBirth = new DateTime(1990, 5, 15), ImageUrl = "/assets/userImgs/user1.jpg" },
                new User { Id = 2, Name = "Fatima Hassan", Email = "fatima@email.com", Location = "Alexandria", Nationality = "Egyptian", DateOfBirth = new DateTime(1988, 8, 22), ImageUrl = "/assets/userImgs/user2.jpg" },
                new User { Id = 3, Name = "Mahmoud Abdullah", Email = "mahmoud@email.com", Location = "Giza", Nationality = "Egyptian", DateOfBirth = new DateTime(1992, 3, 10), ImageUrl = "/assets/userImgs/user3.jpg" }
            );
            #endregion

            #region Hotels Seed
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Golden Nile Hotel", Address = "Cairo", Description = "Luxury 5-star hotel" },
                new Hotel { Id = 2, Name = "North Coast Resort", Address = "North Coast", Description = "Beachfront resort" },
                new Hotel { Id = 3, Name = "Royal Pyramids Hotel", Address = "Giza", Description = "Historic hotel" },
                new Hotel { Id = 4, Name = "Red Sea Resort", Address = "Sharm El Sheikh", Description = "Diving resort" },
                new Hotel { Id = 5, Name = "Alexandria Palace", Address = "Alexandria", Description = "Boutique hotel" }
            );
            #endregion

            #region Rooms Seed (IDs 1-15)
            //Ensure these IDs don't conflict with existing data in your DB
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, RoomType = "Standard", Capacity = 2, Price = 1200m, IsAvailable = true, Sqm = 28f, HotelId = 1, NumberOFBathRoom = 1 },
                new Room { Id = 2, RoomType = "Deluxe", Capacity = 2, Price = 1800m, IsAvailable = true, Sqm = 38f, HotelId = 1, NumberOFBathRoom = 1 },
                new Room { Id = 3, RoomType = "Suite", Capacity = 4, Price = 2800m, IsAvailable = true, Sqm = 55f, HotelId = 1, NumberOFBathRoom = 2 },
                new Room { Id = 4, RoomType = "Standard", Capacity = 2, Price = 1300m, IsAvailable = true, Sqm = 30f, HotelId = 2, NumberOFBathRoom = 1 },
                new Room { Id = 5, RoomType = "Deluxe", Capacity = 2, Price = 2000m, IsAvailable = true, Sqm = 42f, HotelId = 2, NumberOFBathRoom = 1 },
                new Room { Id = 6, RoomType = "Suite", Capacity = 4, Price = 3200m, IsAvailable = true, Sqm = 65f, HotelId = 2, NumberOFBathRoom = 2 },
                new Room { Id = 7, RoomType = "Standard", Capacity = 2, Price = 1100m, IsAvailable = true, Sqm = 26f, HotelId = 3, NumberOFBathRoom = 1 },
                new Room { Id = 8, RoomType = "Deluxe", Capacity = 2, Price = 1700m, IsAvailable = true, Sqm = 40f, HotelId = 3, NumberOFBathRoom = 1 },
                new Room { Id = 9, RoomType = "Suite", Capacity = 4, Price = 2600m, IsAvailable = true, Sqm = 52f, HotelId = 3, NumberOFBathRoom = 2 },
                new Room { Id = 10, RoomType = "Standard", Capacity = 2, Price = 1400m, IsAvailable = true, Sqm = 32f, HotelId = 4, NumberOFBathRoom = 1 },
                new Room { Id = 11, RoomType = "Deluxe", Capacity = 2, Price = 2100m, IsAvailable = true, Sqm = 45f, HotelId = 4, NumberOFBathRoom = 1 },
                new Room { Id = 12, RoomType = "Suite", Capacity = 4, Price = 3500m, IsAvailable = true, Sqm = 70f, HotelId = 4, NumberOFBathRoom = 2 },
                new Room { Id = 13, RoomType = "Standard", Capacity = 2, Price = 1000m, IsAvailable = true, Sqm = 25f, HotelId = 5, NumberOFBathRoom = 1 },
                new Room { Id = 14, RoomType = "Deluxe", Capacity = 2, Price = 1600m, IsAvailable = true, Sqm = 36f, HotelId = 5, NumberOFBathRoom = 1 },
                new Room { Id = 15, RoomType = "Suite", Capacity = 4, Price = 2400m, IsAvailable = true, Sqm = 50f, HotelId = 5, NumberOFBathRoom = 2 }
            );
            #endregion

            #region Images Seed (IDs 1-20)
            modelBuilder.Entity<Image>().HasData(
                // Hotel Images
                new Image { Id = 1, ImageUrl = "/assets/hotelImg/hotel1.jpg", HotelId = 1, RoomId = null },
                new Image { Id = 2, ImageUrl = "/assets/hotelImg/hotel2.jpg", HotelId = 2, RoomId = null },
                new Image { Id = 3, ImageUrl = "/assets/hotelImg/hotel3.jpg", HotelId = 3, RoomId = null },
                new Image { Id = 4, ImageUrl = "/assets/hotelImg/hotel4.jpg", HotelId = 4, RoomId = null },
                new Image { Id = 5, ImageUrl = "/assets/hotelImg/hotel6.jpg", HotelId = 5, RoomId = null },

                // Room Images (Explicitly linked to correct RoomIds)
                new Image { Id = 6, ImageUrl = "/assets/roomImg/room-1.jpg", HotelId = 1, RoomId = 1 },
                new Image { Id = 7, ImageUrl = "/assets/roomImg/room-2.jpg", HotelId = 1, RoomId = 2 },
                new Image { Id = 8, ImageUrl = "/assets/roomImg/room-3.jpg", HotelId = 1, RoomId = 3 },
                new Image { Id = 9, ImageUrl = "/assets/roomImg/room-4.jpg", HotelId = 2, RoomId = 4 },
                new Image { Id = 10, ImageUrl = "/assets/roomImg/room-5.jpg", HotelId = 2, RoomId = 5 },
                new Image { Id = 11, ImageUrl = "/assets/roomImg/room-6.jpg", HotelId = 2, RoomId = 6 },
                new Image { Id = 12, ImageUrl = "/assets/roomImg/room-7.jpg", HotelId = 3, RoomId = 7 },
                new Image { Id = 13, ImageUrl = "/assets/roomImg/room-1.jpg", HotelId = 3, RoomId = 8 },
                new Image { Id = 14, ImageUrl = "/assets/roomImg/room-2.jpg", HotelId = 3, RoomId = 9 },
                new Image { Id = 15, ImageUrl = "/assets/roomImg/room-3.jpg", HotelId = 4, RoomId = 10 },
                new Image { Id = 16, ImageUrl = "/assets/roomImg/room-4.jpg", HotelId = 4, RoomId = 11 },
                new Image { Id = 17, ImageUrl = "/assets/roomImg/room-5.jpg", HotelId = 4, RoomId = 12 },
                new Image { Id = 18, ImageUrl = "/assets/roomImg/room-6.jpg", HotelId = 5, RoomId = 13 },
                new Image { Id = 19, ImageUrl = "/assets/roomImg/room-7.jpg", HotelId = 5, RoomId = 14 },
                new Image { Id = 20, ImageUrl = "/assets/roomImg/room-1.jpg", HotelId = 5, RoomId = 15 }
            );
            #endregion
        }
    }
}
