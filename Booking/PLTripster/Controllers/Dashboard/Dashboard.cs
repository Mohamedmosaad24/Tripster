

using BLTripster.IServices;
using BLTripster.Mapping;
using BLTripster.Services;
using BLTripster.ViewModels;
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
        private readonly IBookingService _bookingService;

        public Dashboard(IHotelService hotelService, IReviewService reviewService, IRoomService roomService, IBookingService bookingService)
        {
            this.hotelService = hotelService;

            this.reviewService = reviewService;
            _roomService = roomService;
            _bookingService = bookingService;
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

            var rooms = _roomService.GetAll()
                .Select(r => new RoomListVM
                {
                    Id = r.Id,
                    RoomType = r.RoomType,
                    Capacity = r.Capacity,
                    Price = r.Price
                }).ToList();

            return View("Rooms", rooms);
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

            return RedirectToAction("Rooms");
        }

        // EDIT ROOM (GET)
        [HttpGet]
        public IActionResult EditRoom(int id)
        {
            var room = _roomService.GetById(id);
            if (room == null)
                return NotFound();

            var roomVM = new RoomVM
            {
                Id = room.Id,
                RoomType = room.RoomType,
                Capacity = room.Capacity,
                Price = room.Price,
                HotelId = room.HotelId
            };

            return View(roomVM);
        }

        // EDIT ROOM (POST)
        [HttpPost]
        public IActionResult EditRoom(RoomVM room)
        {
            if (!ModelState.IsValid)
                return View(model);

            var room = new Room
            {
                Id = model.Id,
                RoomType = model.RoomType,
                Capacity = model.Capacity,
                Price = model.Price,
                HotelId = model.HotelId
            };

            _roomService.Update(room);
            _roomService.Save();

            return RedirectToAction("Rooms");
        }

        // DELETE ROOM
        public IActionResult DeleteRoom(int id)
        {
            _roomService.Delete(id);
            _roomService.Save();

            return RedirectToAction("Rooms");
        }

        #endregion

        #region Bookings dashboard
        //BookingsRepo =>> implemntation  .. Mangement {update}
        [HttpGet]
        public async Task<IActionResult> AllBookings()
        {
            var bookings = await _bookingService.GetAllBookings();

            return View(bookings);
        }

        #endregion

        #region Reviews dashboard
        //ReviewsRepo =>> GetAll/RemoveReview
        [HttpGet]
        public IActionResult AllReviews()
        {
            var reviews = reviewService.GetAll();
            return View("AllReviews", reviews);
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