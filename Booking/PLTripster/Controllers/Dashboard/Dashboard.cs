

using System.ComponentModel.DataAnnotations;
using BLTripster.IServices;
using DATripster.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CenterSystem.Controllers
{
    public class Dashboard : Controller
    {
        private readonly IHotelService hotelService;

        public Dashboard(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }
        #region Home dashboard
        //Display analysis
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Hotel dashboard
        //HotelRepo : IRepo<Room> =>> implemntation..getall/edit/add/getid/delete
        [HttpPost]
        public IActionResult AddHotel(AddHotelVM model)
        {
            if (!ModelState.IsValid)
                return View("Add", model);

            if (model.Images.Count > 5)
            {
                ModelState.AddModelError("", "Maximum 5 images allowed");
                return View("Add",model);
            }

            hotelService.AddHotel(model);

            return RedirectToAction("Index");
        }
        #endregion

        #region Rooms dashboard
        //RoomsRepo : IRepo<Room> =>> implemntation..getall/edit/add/getid/delete

        #endregion

        #region Bookings dashboard
        //BookingsRepo =>> implemntation  .. Mangement {update}

        #endregion

        #region Reviews dashboard
        //ReviewsRepo =>> GetAll/RemoveReview

        #endregion

        #region Users dashboard
        //UsersRepo =>> GetAll /RemoveUser/ActiveAccount

        #endregion
    }
}
