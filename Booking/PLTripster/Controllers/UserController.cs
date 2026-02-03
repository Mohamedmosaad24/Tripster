using BLTripster.IServices;
using BLTripster.Mapping;
using BLTripster.ViewModels;
using DATripster.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PLTripster.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            int currentUserId = 8;

            var user = userService.GetUserById(currentUserId);
            if (user == null)
                return Content($"User with id={currentUserId} not found.");

            var vm = UserProfileMapping.ToProfileVM(user);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = userService.GetUserById(id);
            if (user == null)
                return NotFound($"User with id={id} not found.");

            var vm = UserProfileMapping.ToProfileVM(user);
            return View("EditView", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProfileVM profile)
        {
            if (profile == null)
                return BadRequest("Profile is null.");

            if (!ModelState.IsValid)
                return View("EditView", profile);

            User user = UserProfileMapping.ToUser(profile);
            userService.UpdateUser(user);

            return RedirectToAction(nameof(Index));
        }
    }
}
