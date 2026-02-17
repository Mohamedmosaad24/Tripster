using System.Threading.Tasks;
using BLTripster.IServices;
using BLTripster.Services;
using BLTripster.ViewModels;
using DALTripster.Entities;
using DATripster.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PLTripster.Controllers
{
    public class BookingController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IBookingService _bookingService;

        public IUserService UserService { get; }
        public UserManager<ApplicationUser> UserManager { get; }

        public BookingController(IBookingService bookingService, IRoomService roomService, IUserService userService,
             UserManager<ApplicationUser> userManager)
        {
            _bookingService = bookingService;
            _roomService = roomService;
            UserService = userService;
            UserManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int roomId)
        {
            var room = _roomService.GetById(roomId);
            if (room == null)
                return NotFound();

            if (room.Hotel == null)
                return NotFound("Hotel not found for this room");
            var appUser = await UserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction("Login", "Account");

            var user = UserService.GetUserByEmail(appUser.Email ?? "");

            var model = new BookingPageVM
            {
                HotelName = room.Hotel.Name,
                RoomTypeName = room.RoomType,
                PricePerNight = room.Price,
                MainImageUrl = room.Images?.FirstOrDefault()?.ImageUrl ?? "/assets/Booking/1.jpg",
                Form = new BookingFormVM
                {
                    RoomId = room.Id,
                    UserId = user.Id
                }
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmBooking(BookingFormVM form)
        {
            if (!ModelState.IsValid)
            {
                var pageVm = BuildBookingPageVm(form);
                return View("Index", pageVm);
            }

            var booking = new Booking
            {
                RoomId = form.RoomId,
                UserId = form.UserId,
                CheckIn = form.CheckIn,
                CheckOut = form.CheckOut,
                GuestFullName = form.GuestFullName ?? "",
                GuestEmail = form.GuestEmail ?? "",
                GuestPhone = form.GuestPhone ?? ""
            };

            var bookingId = await _bookingService.CreateBookingAsync(booking);
            if (bookingId <= 0)
            {
                ModelState.AddModelError("", "Unable to complete booking. Please check dates and try again.");
                var pageVm = BuildBookingPageVm(form);
                return View("Index", pageVm);
            }

            return RedirectToAction(nameof(BookingConfirmed), new { bookingId });
        }

        [HttpGet]
        public async Task<IActionResult> BookingConfirmed(int bookingId)
        {
            var booking = await _bookingService.GetBookingDetailsAsync(bookingId);
            if (booking == null)
                return NotFound();

            var viewModel = new BookingSuccessVM
            {
                HotelName = booking.Room.Hotel.Name,
                HotelAddress = booking.Room.Hotel.Address,
                RoomType = booking.Room.RoomType,
                CheckIn = booking.CheckIn ?? DateTime.Now,
                CheckOut = booking.CheckOut ?? DateTime.Now.AddDays(1),
                TotalPrice = booking.TotalPrice,
                MainImageUrl = booking.Room.Images?.FirstOrDefault()?.ImageUrl ?? "/images/default-room.jpg"
            };

            return View(viewModel);
        }

        private BookingPageVM BuildBookingPageVm(BookingFormVM form)
        {
            var room = _roomService.GetById(form.RoomId);
            if (room == null)
                return new BookingPageVM { Form = form };

            return new BookingPageVM
            {
                HotelName = room.Hotel?.Name ?? "",
                RoomTypeName = room.RoomType,
                PricePerNight = room.Price,
                MainImageUrl = room.Images?.FirstOrDefault()?.ImageUrl ?? "/assets/Booking/1.jpg",
                Form = form
            };
        }

    }
}
