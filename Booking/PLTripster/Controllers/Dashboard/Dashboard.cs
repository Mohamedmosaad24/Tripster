

using BLTripster.IServices;
using BLTripster.ViewModels;
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
        //RoomsRepo : IRepo<Room> =>> implemntation..getall/edit/add/getid/delete
        private readonly IRepo<Room> _roomRepo;

        public Dashboard(IRepo<Room> roomRepo)
        {
            _roomRepo = roomRepo;
        }

        // =====================
        // LIST ROOMS
        // =====================
        // LIST ROOMS

        public IActionResult Rooms()
        {
            var rooms = _roomRepo.GetAll()
                .Select(r => r.ToListVM());

            return View(rooms);
        }

        // =====================
        // ADD ROOM (GET)
        // =====================
        public IActionResult AddRoom()
        {
            return View(new RoomVM());
        }

        // =====================
        // ADD ROOM (POST)
        // =====================
        [HttpPost]
        public IActionResult AddRoom(RoomVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _roomRepo.Add(model.ToEntity());
            _roomRepo.Save();

            return RedirectToAction(nameof(Rooms));
        }

        // =====================
        // EDIT ROOM (GET)
        // =====================
        public IActionResult EditRoom(int id)
        {
            var room = _roomRepo.GetById(id);
            if (room == null)
                return NotFound();

            return View(room.ToVM());
        }

        // =====================
        // EDIT ROOM (POST)
        // =====================
        [HttpPost]
        public IActionResult EditRoom(RoomVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _roomRepo.Update(model.ToEntity());
            _roomRepo.Save();

            return RedirectToAction(nameof(Rooms));
        }

        // =====================
        // DELETE ROOM
        // =====================
        public IActionResult DeleteRoom(int id)
        {
            _roomRepo.Delete(id);
            _roomRepo.Save();

            return RedirectToAction("Index");
        }


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