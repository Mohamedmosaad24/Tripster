

using BLTripster.IServices;
using BLTripster.Mapping;
using BLTripster.Services;
using BLTripster.ViewModels;
using DALTripster.IRepos;
using DATripster.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PLTripster.Controllers
{
<<<<<<< HEAD:Booking/PLTripster/Controllers/Dashboard/DashboardController.cs
    public class DashboardController : Controller
=======
    public class    DashboardController   : Controller
>>>>>>> fixRoomAgain:Booking/PLTripster/Controllers/Dashboard/Dashboard.cs
    {
        private readonly IHotelService hotelService;

        private readonly IReviewService reviewService;

        private readonly IRoomService _roomService;
        private readonly IUserService _userService;


        private readonly IBookingService _bookingService;

        public DashboardController(IHotelService hotelService, IReviewService reviewService, IRoomService roomService, IBookingService bookingService,IUserService userService)
        {
            this.hotelService = hotelService;

            this.reviewService = reviewService;
            _roomService = roomService;
            _userService = userService;
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
            return View(new RoomVM());
        }

        //add room (POST)
        [HttpPost]
<<<<<<< HEAD:Booking/PLTripster/Controllers/Dashboard/DashboardController.cs
=======
        [ValidateAntiForgeryToken]
>>>>>>> fixRoomAgain:Booking/PLTripster/Controllers/Dashboard/Dashboard.cs
        public IActionResult AddRoom(RoomVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var room = new Room
            {
                RoomType = model.RoomType,
                Capacity = model.Capacity,
                Price = model.Price,
                HotelId = model.HotelId,
                IsAvailable = true
            };

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

            var model = new RoomVM
            {
                Id = room.Id,
                RoomType = room.RoomType,
                Capacity = room.Capacity,
                Price = room.Price,
                HotelId = room.HotelId
            };

            return View(model);
        }

        // EDIT ROOM (POST)
        [HttpPost]
        public IActionResult EditRoom(RoomVM model)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public IActionResult AllUsers()
        {
            var users = _userService.GetAllUsers();
            return View("AllUsers", users);
        }
        [HttpGet]
        public IActionResult UserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return Content("Invalid User Id");

           return Redirect("user");
        }
        // ===================== Details =====================
        public IActionResult Details(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return View("UserDetails",user);
        }

        // ===================== Edit =====================
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return View("UserEdit",user);
        }

        //[HttpPost]
        //public IActionResult Edit(User user)
        //{
        //    if (!ModelState.IsValid) return View("AllUsers",user);

        //    _userService.UpdateUser(user);
        //    return RedirectToAction("AllUsers");
        //}

        [HttpPost]
        public IActionResult Edit(User user)
        {
            //if (!ModelState.IsValid)
            //    return View("UserEdit", user);  // ✅ ارجع لنفس الـ Edit view

            _userService.UpdateUser(user);
            return RedirectToAction("AllUsers");
        }

        // ===================== Delete =====================
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return View("UserDelete",user); 
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("AllUsers");
        }
        ////=======================Add=====================
        //[HttpGet]
        //public IActionResult AddUser()
        //{
        //    return View("UserAdd");
        //}

        //[HttpPost]
        //public IActionResult Create(User user)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //}
        //        return View("AllUsers", user);

        //    _userService.AddUser(user);
        //    return RedirectToAction("AllUsers");
        //}

        [HttpGet]
        public IActionResult AddUser()
        {
            return View("UserAdd");
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            //if (!ModelState.IsValid)
            //{
            //}
                return View("UserAdd", user);  // ✅ ارجع لـ UserAdd لو فيه errors

            _userService.AddUser(user);
            return RedirectToAction("AllUsers");  // ✅ redirect بعد النجاح
        }
        #endregion
    }
}