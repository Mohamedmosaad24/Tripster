using BLTripster.IServices;
using Microsoft.AspNetCore.Mvc;

namespace PLTripster.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewServices;

        public ReviewsController(IReviewService reviewServices)
        {
            _reviewServices = reviewServices;
        }
        public IActionResult Reviews()
        {
            var revs = _reviewServices.GetAll();
            return View("reviews" , revs);
        }
    }
}
