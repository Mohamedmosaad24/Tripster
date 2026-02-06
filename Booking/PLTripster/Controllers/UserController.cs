using BLTripster.IServices;
using BLTripster.Mapping;
using BLTripster.ViewModels;
using DALTripster.Entities;
using DATripster.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace PLTripster.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var appUser = await _userManager.GetUserAsync(User);
            if (appUser == null)
                return RedirectToAction("Login", "Account");

            var user = userService.GetUserByEmail(appUser.Email ?? "");
            if (user == null)
            {
                user = new User
                {
                    Name = appUser.FullName ?? appUser.UserName ?? "",
                    Email = appUser.Email ?? ""
                };
                userService.AddUser(user);
                user = userService.GetUserByEmail(appUser.Email ?? "");
            }

            if (user == null)
                return Content("Profile could not be loaded.");

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
