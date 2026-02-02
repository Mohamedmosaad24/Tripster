using BLTripster.IServices;
using DATripster.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PLTripster.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;
        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }
        public IActionResult Index()
        {
            var result = searchService.GetAll();
            return View("Result", result);
        }
        public IActionResult Result(string destination, DateTime checkIn, DateTime checkOut, int guests)
        {
           var result = searchService.Search(destination,checkIn,checkOut,guests);
            Console.WriteLine(result.Count());
            @ViewBag.geusts = guests;
            @ViewBag.location = destination;
            @ViewBag.nights = (checkOut - checkIn).Days;
            @ViewBag.in_out = $"{checkIn:MMM d} - {checkOut: d}";
            
            return View(result);
        }
        public IActionResult Filter(string service, int price, int rating)
        {
            var result = searchService.Filter(service, price, rating);
            return View("Result",result);
        }
        public IActionResult Sort(string sortBY)
        {
            var result = searchService.Sort(sortBY);
            return View("Result", result);
        }

    }
}
