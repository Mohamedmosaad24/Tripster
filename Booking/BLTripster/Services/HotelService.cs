using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLTripster.IServices;
using BLTripster.ViewModels;
using DALTripster.IRepos;
using DALTripster.Repos;
using DATripster.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BLTripster.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepo hotelRepo;

        private readonly ISearchRepo searchRepo;

        public HotelService(IHotelRepo hotelRepo,ISearchRepo searchRepo)
        {
            this.hotelRepo = hotelRepo;
            this.searchRepo = searchRepo;
        }

        public List<HotelListVM> GetAllHotels()
        {
            var hotels = searchRepo.GetAll();

            return hotels.Select(h => new HotelListVM
                {
                    Id = h.Id,
                    Name = h.Name,
                    Address = h.Address,
                    Description = h.Description,
                    Latitude = h.Latitude,
                    Longitude = h.Longitude,
                    ImageUrls = h.Images.Select(img => img.ImageUrl ?? "").ToList()
                })
                .ToList();
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
                var path = Path.Combine("wwwroot/assets/hotelImg", fileName);

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
        public void EditHotel(EditHotelVM model)
        {
            var Hotels = hotelRepo.GetAll();
            var hotel = Hotels.FirstOrDefault(h => h.Id == model.Id);

            if (hotel == null)
                throw new Exception("Hotel not found");

            hotel.Name = model.Name;
            hotel.Address = model.Address;
            hotel.Description = model.Description;
            hotel.Latitude = model.Latitude;
            hotel.Longitude = model.Longitude;

            if (model.Images.Any())
            {
                SaveImages(hotel, model.Images);
            }

            hotelRepo.Save();
        }
        public Hotel GetHotel(int id)
        {
            var hotel = hotelRepo.GetById(id);
            return hotel;
        }

        public void Delete(int id)
        {
            hotelRepo.Delete(id);
        }
        private void SaveImages(Hotel hotel, List<IFormFile> images)
        {

            hotelRepo.DeleteImg(hotel.Id);
            foreach (var file in images)
            {
                if (file.Length == 0) continue;

                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var uploadDir = Path.Combine("wwwroot", "assets", "hotelImg");


                var path = Path.Combine(uploadDir, fileName);

                using var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);

                hotel.Images.Add(new Image { ImageUrl = fileName });
            }
        }

    }
}
