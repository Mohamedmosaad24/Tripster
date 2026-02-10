using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATripster.Entities;
  using Microsoft.EntityFrameworkCore;
 
    namespace DATripster.Data.Seeds
    {
        public static class RoomSeed
        {
            public static void Seed(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Room>().HasData(
                    new Room
                    {
                        Id = 1,
                        RoomType = "Single Room",
                        Capacity = 1,
                        Price = 120,
                        IsAvailable = true,
                        Sqm = 18,
                        NumberOFBathRoom = 1,
                        TypeOfBed = TypeOfBed.King,
                        HotelId = 1
                    },
                    new Room
                    {
                        Id = 2,
                        RoomType = "Double Room",
                        Capacity = 2,
                        Price = 180,
                        IsAvailable = true,
                        Sqm = 25,
                        NumberOFBathRoom = 1,
                        TypeOfBed = TypeOfBed.Queen,
                        HotelId = 1
                    },
                        new Room
                        {
                            Id = 3,
                            RoomType = "Suite",
                            Capacity = 3,
                            Price = 250,
                            IsAvailable = true,
                            Sqm = 35,
                            NumberOFBathRoom = 2,
                            TypeOfBed = TypeOfBed.King,
                            HotelId = 1
                        },

    new Room
    {
        Id = 4,
        RoomType = "Family Room",
        Capacity = 4,
        Price = 300,
        IsAvailable = true,
        Sqm = 40,
        NumberOFBathRoom = 2,
        TypeOfBed = TypeOfBed.Queen,
        HotelId = 1
    },

    new Room
    {
        Id = 5,
        RoomType = "Deluxe Room",
        Capacity = 2,
        Price = 220,
        IsAvailable = true,
        Sqm = 30,
        NumberOFBathRoom = 1,
        TypeOfBed = TypeOfBed.King,
        HotelId = 1
    },

    new Room
    {
        Id = 6,
        RoomType = "King Room",
        Capacity = 2,
        Price = 260,
        IsAvailable = true,
        Sqm = 32,
        NumberOFBathRoom = 1,
        TypeOfBed = TypeOfBed.King,
        HotelId = 1
    },

    new Room
    {
        Id = 7,
        RoomType = "Queen Room",
        Capacity = 2,
        Price = 240,
        IsAvailable = true,
        Sqm = 28,
        NumberOFBathRoom = 1,
        TypeOfBed = TypeOfBed.Queen,
        HotelId = 1
    }





                );
            }
        }
    }
