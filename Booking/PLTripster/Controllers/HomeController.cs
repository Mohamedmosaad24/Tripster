using BLTripster.IServices;
using Microsoft.AspNetCore.Mvc;
using PLTripster.Models;
using System.Diagnostics;

namespace PLTripster.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            var hotels = _homeService.GetAll().Take(5).ToList();

            return View(hotels);
        }
        public IActionResult Search(string? city, DateTime? checkIn, DateTime? checkOut, int? guests)
        {
            if (string.IsNullOrWhiteSpace(city)
                || !checkIn.HasValue
                || !checkOut.HasValue)
            {
                return RedirectToAction("Result", "Search");
            }

            return RedirectToAction("Result", "Search", new
            {
                destination = city,
                checkIn = checkIn,
                checkOut = checkOut,
                guests = guests ?? 1
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
