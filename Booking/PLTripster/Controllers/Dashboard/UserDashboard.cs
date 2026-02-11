//using BLTripster.IServices;
//using Microsoft.AspNetCore.Mvc;

//namespace PLTripster.Controllers.Dashboard
//{
//    public class UserDashboard : Controller
//    {
//        private readonly IUserService userService;

//        public UserDashboard(IUserService userService)
//        {
//            this.userService = userService;
//        }
//        [HttpGet]
//        public IActionResult AllUsers()
//        {
//            var users = userService.GetAllUsers();
//            return View("Index",users);
//        }
//        [HttpGet]
//        public IActionResult Details(int id)
//        {
//            var user = userService.GetUserById(id);

//            if (user == null)
//                return Content("Invalid User Id");

//            return View(user);
//        }
//    }
//}
