using DATripster.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTripster.Data.Seeds
{
    internal class BookingSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    CheckIn = new DateTime(2026, 2, 10),
                    CheckOut = new DateTime(2026, 2, 12),
                    TotalPrice = 240,
                    RoomId = 1,
                    UserId = 1
                }
            );
        }
    }
}

    