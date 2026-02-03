using BLTripster.IServices;
using DALTripster.IRepos;
using DATripster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTripster.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepo hotelRepo;
        public HotelService(IHotelRepo hotelRepo)
        {
            this.hotelRepo = hotelRepo;
        }
        public Hotel GetHotel(int id)
        {
            var hotel =  hotelRepo.GetById(id);
            return hotel;
        }
    }
}
