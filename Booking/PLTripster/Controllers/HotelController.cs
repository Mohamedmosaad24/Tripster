using BLTripster.IServices;
using Microsoft.AspNetCore.Mvc;

namespace PLTripster.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService hotelService;
        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }
        public IActionResult Details(int id)
        {
            var hotel = hotelService.GetHotel(id);
            if (hotel == null)
            {
                return NotFound(); 
            }
            return View("details" , hotel);
        }
    }
}
