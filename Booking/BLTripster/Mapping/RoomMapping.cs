using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLTripster.ViewModels;

using DATripster.Entities;

namespace BLTripster.Mapping
{
        public static class RoomMapping
        {
            public static RoomVM ToVM(this Room room)
            {
                return new RoomVM
                {
                    Id = room.Id,
                    RoomType = room.RoomType,
                    Capacity = room.Capacity,
                    Price = room.Price,
                    IsAvailable = room.IsAvailable,
                    HotelId = room.HotelId
                };
            }

            public static Room ToEntity(this RoomVM vm)
            {
                return new Room
                {
                    Id = vm.Id,
                    RoomType = vm.RoomType,
                    Capacity = vm.Capacity,
                    Price = vm.Price,
                    IsAvailable = vm.IsAvailable,
                    HotelId = vm.HotelId
                };
            }

            public static RoomListVM ToListVM(this Room room)
            {
                return new RoomListVM
                {
                    Id = room.Id,
                    RoomType = room.RoomType,
                    Capacity = room.Capacity,
                    Price = room.Price
                };
            }
        }
    }


