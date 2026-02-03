
using BLTripster.IServices;
using DATripster.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public IActionResult BookingConfirmed()
        {
           
            return View(BookingConfirmed);
        }
    }
}
