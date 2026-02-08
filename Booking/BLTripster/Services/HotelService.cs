using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLTripster.IServices;
using DALTripster.IRepos;
using DATripster.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLTripster.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepo hotelRepo;
        public HotelService(IHotelRepo hotelRepo)
        {
            this.hotelRepo = hotelRepo;
        }

        public void AddHotel(AddHotelVM model)
        {
            var hotel = new Hotel
            {
                Name = model.Name,
                Address = model.Address,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Description = model.Description,
                Images = new List<Image>()
            };

            foreach (var file in model.Images)
            {
                if (file.Length == 0) continue;

                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var path = Path.Combine("wwwroot/images/hotels", fileName);

                using var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);

                hotel.Images.Add(new Image
                {
                    ImageUrl = fileName
                });
            }

            hotelRepo.Add(hotel);
            hotelRepo.Save();
        }
        public Hotel GetHotel(int id)
        {
            var hotel =  hotelRepo.GetById(id);
            return hotel;
        }
    }
}
