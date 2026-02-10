using BLTripster.ViewModels;
using DATripster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTripster.IServices
{
    public interface IHotelService
    {
        List<HotelListVM> GetAllHotels();
        Hotel GetHotel(int id);
        void AddHotel(AddHotelVM hotel);
        void EditHotel(EditHotelVM model);
        public void Delete(int id);

    }
}
