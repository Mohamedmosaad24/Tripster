using DATripster.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTripster.Data.Seeds
{
    public class UserSeed
    {

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Islam Soliman",
                    Email = "islam@test.com",
                    Location = "Egypt",
                    Nationality = "Egyptian",
                    DateOfBirth = new DateTime(1999, 1, 1),
                    ImageUrl = "/assets/users/user1.jpg"
                },
                new User
                {
                    Id = 2,
                    Name = "John Doe",
                    Email = "john@test.com",
                    Location = "USA",
                    Nationality = "American",
                    DateOfBirth = new DateTime(1990, 5, 10)
                }
            );
        }
    }


}

