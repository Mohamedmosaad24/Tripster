using DATripster.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTripster.Data.Seeds
{
    public class ServiceSeed
    {

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Free Wi-Fi" },
                new Service { Id = 2, Name = "Breakfast Included" },
                new Service { Id = 3, Name = "Swimming Pool" }
            );
        }
    }


}

