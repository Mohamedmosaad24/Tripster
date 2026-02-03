
using BLTripster.IServices;
using DATripster.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTripster.ViewModels;

namespace WebTripster.Controllers
{
    public class BookingController : Controller
    {
        
        private readonly IBookingService _bookingService;

       
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
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
    }
}
