using DATripster.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTripster.Data.Seeds
{
    internal class HotelServiceSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelService>().HasData(
                new HotelService { HotelId = 1, ServiceId = 1 },
                new HotelService { HotelId = 1, ServiceId = 2 },
                new HotelService { HotelId = 2, ServiceId = 1 },
                new HotelService { HotelId = 2, ServiceId = 3 }
            );
        }
    }


}
