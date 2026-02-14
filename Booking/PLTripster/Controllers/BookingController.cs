using BLTripster.IServices;
using BLTripster.Services;
using BLTripster.ViewModels;
using DATripster.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PLTripster.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using WebTripster.ViewModels;

namespace WebTripster.Controllers
{
    public class BookingController : Controller
    {
        public readonly IRoomService RoomService;

        private readonly IBookingService _bookingService;


        public BookingController(IBookingService bookingService, IRoomService roomService)
        {
            _bookingService = bookingService;
            RoomService = roomService;
        }

        //[HttpPost]
        //public async Task<IActionResult> ConfirmBooking(BookingFormVM form)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Error");
        //    }

        //    var booking = new Booking
        //    {
        //        RoomId = form.RoomId,
        //        UserId = form.UserId,
        //        CheckIn = form.CheckIn,
        //        CheckOut = form.CheckOut,
        //        GuestFullName = form.GuestFullName,
        //        GuestEmail = form.GuestEmail,
        //        GuestPhone = form.GuestPhone
        //    };

        //    var success = await _bookingService.CreateBookingAsync(booking);

        //    if (success)
        //        return RedirectToAction("BookingConfirmed", new { bookingId = booking.Id });

        //    return View("Error");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmBooking(BookingFormVM form)
        {
            if (form == null || form.RoomId <= 0)
            {
                return RedirectToAction(nameof(Index), new { roomId = form?.RoomId ?? 1 });
            }

            if (!ModelState.IsValid)
            {
                var room = RoomService.GetById(form.RoomId);
                var pageModel = new BookingPageVM
                {
                    Form = form,
                    HotelName = room?.Hotel?.Name ?? "N/A",
                    RoomTypeName = room?.RoomType ?? "N/A",
                    PricePerNight = room?.Price ?? 0,
                    MainImageUrl = room?.Images?.FirstOrDefault()?.ImageUrl ?? "/assets/Booking/1.jpg"
                };
                return View("Index", pageModel);
            }

            var booking = new Booking
            {
                RoomId = form.RoomId,
                UserId = form.UserId,
                CheckIn = form.CheckIn,
                CheckOut = form.CheckOut,
                GuestFullName = form.GuestFullName,
                GuestEmail = form.GuestEmail ?? "",
                GuestPhone = form.GuestPhone ?? "",
                TotalPrice = form.GetTotalPrice((form.CheckOut.Value - form.CheckIn.Value).Days)
            };

            int newBookingId = await _bookingService.CreateBookingAsync(booking);

            if (newBookingId > 0)
            {
                Response.Headers.Location = Url.Action(nameof(BookingConfirmed), "Booking", new { bookingId = newBookingId });
                return StatusCode(303);
            }

            return RedirectToAction(nameof(Index), new { roomId = form.RoomId });
        }

        [HttpGet]
        public async Task<IActionResult> BookingConfirmed(int bookingId)
        {
            var booking = await _bookingService.GetBookingDetailsAsync(bookingId);

            if (booking == null) return NotFound();

            var viewModel = new BookingSuccessVM
            {
                RoomId = booking.RoomId,
                HotelName = booking.Room?.Hotel?.Name ?? "Tripster Hotel",
                HotelAddress = booking.Room?.Hotel?.Address ?? "Address not available",
                RoomType = booking.Room?.RoomType ?? "Standard Room",
                CheckIn = booking.CheckIn ?? DateTime.Now,
                CheckOut = booking.CheckOut ?? DateTime.Now.AddDays(1),
                TotalPrice = booking.TotalPrice,
                MainImageUrl = booking.Room?.Images?.FirstOrDefault()?.ImageUrl ?? "/images/default-room.jpg"
            };

            return View("BookingConfirmed", viewModel);
        }

        [HttpGet]
        public IActionResult Index(int roomId)
        {
            var room = RoomService.GetById(roomId);

            if (room == null)
                return NotFound("Room not found");

            if (room.Hotel == null)
                return NotFound("Hotel not found for this room");

            var model = new BookingPageVM
            {
                HotelName = room.Hotel.Name,
                RoomTypeName = room.RoomType,
                PricePerNight = room.Price,
                MainImageUrl = room.Images?
                    .FirstOrDefault()?.ImageUrl
                    ?? "/assets/Booking/1.jpg",

                Form = new BookingFormVM
                {
                    RoomId = room.Id,
                    UserId = 1
                }
            };

            return View(model);
        }

    }
}
