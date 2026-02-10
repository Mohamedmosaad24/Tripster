using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATripster.Entities;
using Microsoft.EntityFrameworkCore;



namespace DATripster.Data.Seeds
{
    public static class ImageSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>().HasData(

                new Image
                {
                    Id = 1,
                    ImageUrl = "/assets/RoomImg/room-1.jpg",
                    RoomId = 1
                },
                new Image
                {
                    Id = 2,
                    ImageUrl = "/assets/RoomImg/room-2.jpg",
                    RoomId = 2
                },
                new Image
                {
                    Id = 3,
                    ImageUrl = "/assets/RoomImg/room-3.jpg",
                    RoomId = 3
                },
                new Image
                {
                    Id = 4,
                    ImageUrl = "/assets/RoomImg/room-4.jpg",
                    RoomId = 4
                },
                new Image
                {
                    Id = 5,
                    ImageUrl = "/assets/RoomImg/room-5.jpg",
                    RoomId = 5
                },
                new Image
                {
                    Id = 6,
                    ImageUrl = "/assets/RoomImg/room-6.jpg",
                    RoomId = 6
                },
                new Image
                {
                    Id = 7,
                    ImageUrl = "/assets/RoomImg/room-7.jpg",
                    RoomId = 7
                }
            );
        }
    }
}

