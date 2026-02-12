using BLTripster.IServices;
using BLTripster.ViewModels;
using DALTripster.IRepos;
using DATripster.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PLTripster.Controllers.Dashboard
{
    public class DashboardHotel : Controller
    {
        private readonly IHotelService hotelService;
        private readonly IRepo<Room> _roomRepo;

        public DashboardHotel(IHotelService hotelService)
        {
            this.hotelService = hotelService;
            //_roomRepo = roomRepo;
        }
        #region Home dashboard
        //Display analysis
        public IActionResult Index()
        {
            var hotels = hotelService.GetAllHotels();
            return View("IndexHotel",hotels);
            
        }
        #endregion

        #region Hotel dashboard
        public IActionResult IndexHotel()
        {
            var hotels = hotelService.GetAllHotels();
            return View(hotels);
        }
        public IActionResult AddHotel(AddHotelVM model)
        {
            return View("AddHotel", model);
        }

        public IActionResult SaveHotel(AddHotelVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Images.Count > 5)
            {
                ModelState.AddModelError("", "Maximum 5 images allowed");
                return View(model);
            }

            hotelService.AddHotel(model);


            return RedirectToAction("Index");
        }
        //edit
        public IActionResult EditeHotel(int id)
        {
            var hotel = hotelService.GetHotel(id);

            if (hotel == null) return NotFound();

            var model = new EditHotelVM
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Address = hotel.Address,
                Description = hotel.Description,
                Latitude = hotel.Latitude,
                Longitude = hotel.Longitude
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveEditHotel(EditHotelVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Images.Count > 5)
            {
                ModelState.AddModelError("", "Maximum 5 images allowed");
                return View(model);
            }

            hotelService.EditHotel(model);

            return RedirectToAction("Index");
        }
        //delete
        public IActionResult Delete(int id)
        {
            hotelService.Delete(id);
            return RedirectToAction("indexHotel");
        }
        #endregion
    }
}
