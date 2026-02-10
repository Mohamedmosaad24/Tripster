

using BLTripster.IServices;
using DALTripster.IRepos;
using DATripster.Entities;
using Microsoft.AspNetCore.Mvc;
using BLTripster.Mapping;
using System.ComponentModel.DataAnnotations;

namespace DALTripster.Controllers
{
    public class Dashboard : Controller
    {
        private readonly IHotelService hotelService;
        private readonly IRepo<Room> _roomRepo;
        private readonly IReviewService reviewService;

        public Dashboard(IHotelService hotelService, IRepo<Room> roomRepo, IReviewService reviewService)
        {   
            this.hotelService = hotelService;
            _roomRepo = roomRepo;
            this.reviewService = reviewService;
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
        // Updated upstream

        [HttpPost]

        public IActionResult AddHotel(AddHotelVM model)
        {
            if (!ModelState.IsValid)
                return View("Add", model);
            // Stashed changes

            return RedirectToAction("Index");
        }
        #endregion





        #region Rooms dashboard
 


        #endregion

        #region Bookings dashboard
        //BookingsRepo =>> implemntation  .. Mangement {update}

        #endregion

        #region Reviews dashboard
        //ReviewsRepo =>> GetAll/RemoveReview
        [HttpGet]
        public IActionResult Reviews()
        {
            var reviews = reviewService.GetAll();
            return View(reviews);
        }

        [HttpPost]
        public IActionResult RemoveReview(int reviewId)
        {
            reviewService.RemoveReview(reviewId);
            return RedirectToAction("Index");
        }

        #endregion

        #region Users dashboard
        //UsersRepo =>> GetAll /RemoveUser/ActiveAccount

        #endregion
    }
}