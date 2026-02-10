
using BLTripster.IServices;
using BLTripster.Services;
using BLTripster.ViewModels;
using DATripster.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
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

        [HttpPost]
        public async Task<IActionResult> ConfirmBooking(Booking model)
        {
          
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

     
            bool success = await _bookingService.CreateBookingAsync(model);

            if (success)
            {
                
                return RedirectToAction("BookingConfirmed");
            }

            return View("Error");
        }

        [HttpGet]
        public async Task<IActionResult> BookingConfirmed(int bookingId)
        {
          
            var booking = await _bookingService.GetBookingDetailsAsync(bookingId);

            if (booking == null) return NotFound();

         
            var viewModel = new BookingSuccessVM
            {
                HotelName = booking.Room.Hotel.Name,
                HotelAddress = booking.Room.Hotel.Address,
                RoomType = booking.Room.RoomType,
                CheckIn = booking.CheckIn ?? DateTime.Now,
                CheckOut = booking.CheckOut ?? DateTime.Now.AddDays(1),
                TotalPrice = booking.TotalPrice,
             
                MainImageUrl = booking.Room.Images?.FirstOrDefault()?.ImageUrl
                               ?? "/images/default-room.jpg"
            };

            return View(viewModel);
        }


        [HttpGet]
public IActionResult Index(int roomId)
{
            var room = RoomService.GetRoomById(roomId);

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
