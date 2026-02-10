using DATripster.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTripster.Data.Seeds
{
    internal class ReviewSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    Rate = 5,
                    Comment = "Excellent stay!",
                    HotelId = 1,
                    UserId = 1
                },
                new Review
                {
                    Id = 2,
                    Rate = 4,
                    Comment = "Very good service",
                    HotelId = 2,
                    UserId = 2
                }
            );
        }
    }


}

