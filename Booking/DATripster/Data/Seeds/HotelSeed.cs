using DATripster.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTripster.Data.Seeds
{
    internal class HotelSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Hotel Norrebro",
                    Address = "Copenhagen, Denmark",
                    Description = "Modern hotel in city center",
                    Latitude = 55.685,
                    Longitude = 12.561
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Sea View Resort",
                    Address = "Hurghada, Egypt",
                    Description = "Resort with sea view",
                    Latitude = 27.2579,
                    Longitude = 33.8116
                }
            );
        }
    }

}

