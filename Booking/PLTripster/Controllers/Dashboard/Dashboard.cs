

using BLTripster.IServices;
using BLTripster.Mapping;
using BLTripster.Services;
using DALTripster.IRepos;
using DATripster.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DALTripster.Controllers
{
    public class Dashboard : Controller
    {
        private readonly IHotelService hotelService;

        private readonly IReviewService reviewService;

        private readonly IRoomService _roomService;
        public Dashboard(IHotelService hotelService, IReviewService reviewService, IRoomService roomService)
        {
            this.hotelService = hotelService;

            this.reviewService = reviewService;
            _roomService = roomService;
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

        // LIST ROOMS
        public IActionResult Rooms()
        {
            var rooms = _roomService.GetAll();
            return View(rooms);
        }

        // ADD ROOM (GET)
        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }

        // ADD ROOM (POST)
        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            if (!ModelState.IsValid)
                return View(room);

            _roomService.Add(room);
            _roomService.Save();

            return RedirectToAction(nameof(Rooms));
        }

        // EDIT ROOM (GET)
        [HttpGet]
        public IActionResult EditRoom(int id)
        {
            var room = _roomService.GetById(id);
            if (room == null)
                return NotFound();

            return View(room);
        }

        // EDIT ROOM (POST)
        [HttpPost]
        public IActionResult EditRoom(Room room)
        {
            if (!ModelState.IsValid)
                return View(room);

            _roomService.Update(room);
            _roomService.Save();

            return RedirectToAction(nameof(Rooms));
        }

        // DELETE ROOM
        public IActionResult DeleteRoom(int id)
        {
            _roomService.Delete(id);
            _roomService.Save();

            return RedirectToAction(nameof(Rooms));
        }

        #endregion

        #region Bookings dashboard
        //BookingsRepo =>> implemntation  .. Mangement {update}

        #endregion

        #region Reviews dashboard
        //ReviewsRepo =>> GetAll/RemoveReview
        [HttpGet]
        public IActionResult AllReviews()
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