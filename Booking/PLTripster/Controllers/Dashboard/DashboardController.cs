

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
    public class DashboardController : Controller

    {
        private readonly IHotelService hotelService;

        private readonly IReviewService reviewService;

        private readonly IRoomService _roomService;
        private readonly IUserService _userService;


        private readonly IBookingService _bookingService;

        public DashboardController(IHotelService hotelService, IReviewService reviewService, IRoomService roomService, IBookingService bookingService, IUserService userService)
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
                   Price = r.Price,
                   ImageUrl = r.Images?.FirstOrDefault()?.ImageUrl
               }).ToList();

            return View("Rooms", rooms);
        }

        // ADD ROOM (GET)
        [HttpGet]
        public IActionResult AddRoom()
        {
            var hotels = hotelService.GetAllHotels();
            if (hotels == null || hotels.Count == 0)
            {
                TempData["Error"] = "No hotels found. Please add a hotel first.";
                return RedirectToAction("Rooms");
            }
            var model = new RoomVM { HotelId = hotels[0].Id };
            ViewBag.Hotels = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(hotels, "Id", "Name", model.HotelId);
            return View(model);
        }

        //add room (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRoom(RoomVM model, IFormFile? RoomImage)
        {
            var hotel = hotelService.GetHotel(model.HotelId);
            if (hotel == null)
                ModelState.AddModelError("HotelId", "Please select a valid hotel.");

            if (!ModelState.IsValid)
            {
                ViewBag.Hotels = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(hotelService.GetAllHotels(), "Id", "Name", model.HotelId);
                return View(model);
            }

            // Handle room image upload
            string? imageUrl = null;
            if (RoomImage != null && RoomImage.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(RoomImage.FileName).ToLowerInvariant();
                if (allowedExtensions.Contains(extension) && RoomImage.Length <= 5 * 1024 * 1024)
                {
                    var fileName = $"room_{Guid.NewGuid()}{extension}";
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "rooms");
                    Directory.CreateDirectory(uploadsFolder);
                    var filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await RoomImage.CopyToAsync(stream);
                    }
                    imageUrl = $"/uploads/rooms/{fileName}";
                }
            }

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

            if (!string.IsNullOrWhiteSpace(imageUrl))
            {
                _roomService.AddImageForRoom(room.Id, imageUrl);
                _roomService.Save();
            }

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
                HotelId = room.HotelId,
                ImageUrl = room.Images?.FirstOrDefault()?.ImageUrl
            };
            ViewBag.Hotels = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(hotelService.GetAllHotels(), "Id", "Name", model.HotelId);
            return View(model);
        }

        // EDIT ROOM (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRoom(RoomVM model, IFormFile? RoomImage)
        {
            var hotel = hotelService.GetHotel(model.HotelId);
            if (hotel == null)
                ModelState.AddModelError("HotelId", "Please select a valid hotel.");

            if (!ModelState.IsValid)
            {
                ViewBag.Hotels = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(hotelService.GetAllHotels(), "Id", "Name", model.HotelId);
                return View(model);
            }

            // Handle room image upload
            string? imageUrl = null;
            if (RoomImage != null && RoomImage.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(RoomImage.FileName).ToLowerInvariant();
                if (allowedExtensions.Contains(extension) && RoomImage.Length <= 5 * 1024 * 1024)
                {
                    var fileName = $"room_{model.Id}_{Guid.NewGuid()}{extension}";
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "rooms");
                    Directory.CreateDirectory(uploadsFolder);
                    var filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await RoomImage.CopyToAsync(stream);
                    }
                    imageUrl = $"/uploads/rooms/{fileName}";
                }
            }

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

            if (!string.IsNullOrWhiteSpace(imageUrl))
            {
                _roomService.SetFirstImageForRoom(model.Id, imageUrl);
                _roomService.Save();
            }

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
                return NotFound();

            return RedirectToAction(nameof(Details), new { id });
        }
        // ===================== Details =====================
        public IActionResult Details(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return View("UserDetails", user);
        }

        // ===================== Edit =====================
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return View("UserEdit", user);
        }

        //[HttpPost]
        //public IActionResult Edit(User user)
        //{
        //    if (!ModelState.IsValid) return View("AllUsers",user);

        //    _userService.UpdateUser(user);
        //    return RedirectToAction("AllUsers");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user, IFormFile? ProfileImage)
        {
            if (user == null) return NotFound();

            // Handle profile image upload
            if (ProfileImage != null && ProfileImage.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(ProfileImage.FileName).ToLowerInvariant();
                if (allowedExtensions.Contains(extension) && ProfileImage.Length <= 5 * 1024 * 1024)
                {
                    // Delete old profile image if it exists
                    if (!string.IsNullOrEmpty(user.ImageUrl))
                    {
                        var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", user.ImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                        if (System.IO.File.Exists(oldPath))
                            System.IO.File.Delete(oldPath);
                    }

                    var fileName = $"profile_{user.Id}_{Guid.NewGuid()}{extension}";
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "profiles");
                    Directory.CreateDirectory(uploadsFolder);
                    var filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ProfileImage.CopyToAsync(stream);
                    }
                    user.ImageUrl = $"/uploads/profiles/{fileName}";
                }
            }

            _userService.UpdateUser(user);
            return RedirectToAction(nameof(AllUsers));
        }

        // ===================== Delete =====================
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return View("UserDelete", user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete profile image file from disk before removing user
            var user = _userService.GetUserById(id);
            if (user != null && !string.IsNullOrEmpty(user.ImageUrl))
            {
                var imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", user.ImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (System.IO.File.Exists(imgPath))
                    System.IO.File.Delete(imgPath);
            }

            _userService.DeleteUser(id);
            return RedirectToAction(nameof(AllUsers));
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user, IFormFile? ProfileImage)
        {
            if (!ModelState.IsValid)
                return View("UserAdd", user);

            // Handle profile image upload
            if (ProfileImage != null && ProfileImage.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(ProfileImage.FileName).ToLowerInvariant();
                if (allowedExtensions.Contains(extension) && ProfileImage.Length <= 5 * 1024 * 1024)
                {
                    var fileName = $"profile_{Guid.NewGuid()}{extension}";
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "profiles");
                    Directory.CreateDirectory(uploadsFolder);
                    var filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ProfileImage.CopyToAsync(stream);
                    }
                    user.ImageUrl = $"/uploads/profiles/{fileName}";
                }
            }

            _userService.AddUser(user);
            return RedirectToAction(nameof(AllUsers));
        }
        #endregion
    }
}