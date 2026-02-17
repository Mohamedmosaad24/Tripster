using System.Security.Claims;
using BLTripster.IServices;
using BLTripster.Mapping;
using BLTripster.Services;
using BLTripster.ViewModels;
using DALTripster.Entities;
using DATripster.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PLTripster.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IBookingService BookingService { get; }

        public UserController(IUserService userService, IBookingService bookingService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            BookingService = bookingService;
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
        public async Task<IActionResult> Edit(ProfileVM profile, IFormFile? ProfileImage)
        {
            if (profile == null)
                return BadRequest("Profile is null.");

            if (!ModelState.IsValid)
                return View("EditView", profile);

            // Handle image upload
            if (ProfileImage != null && ProfileImage.Length > 0)
            {
                // Validate file type
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(ProfileImage.FileName).ToLowerInvariant();
                
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("ProfileImage", "Please upload a valid image file (JPG, PNG, GIF).");
                    return View("EditView", profile);
                }

                // Validate file size (max 5MB)
                if (ProfileImage.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("ProfileImage", "File size must be less than 5MB.");
                    return View("EditView", profile);
                }

                // Generate unique filename
                var fileName = $"profile_{profile.Id}_{Guid.NewGuid()}{extension}";
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "profiles");
                Directory.CreateDirectory(uploadsFolder);
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Delete old profile image if it exists
                if (!string.IsNullOrEmpty(profile.ImageUrl))
                {
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", profile.ImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                // Save file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfileImage.CopyToAsync(stream);
                }

                // Update profile image URL
                profile.ImageUrl = $"/uploads/profiles/{fileName}";
            }

            User user = UserProfileMapping.ToUser(profile);
            userService.UpdateUser(user);

            return RedirectToAction(nameof(Index));
        }

        //get bookings
        [Authorize]
        public async Task<IActionResult> MyBookings()
        {
            var appUser = await _userManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction("Login", "Account");

            var user = userService.GetUserByEmail(appUser.Email ?? "");

            if (user == null)
                return NotFound("User not found.");

            var bookings = await BookingService.GetUserBookingsAsync(user.Id);

            return View(bookings);
        }

        //cancel

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var appUser = await _userManager.GetUserAsync(User);
            if (appUser == null)
                return RedirectToAction("Login", "Account");

            var user = userService.GetUserByEmail(appUser.Email ?? "");
            if (user == null)
                return NotFound("User not found.");

            var success = await BookingService.CancelBookingAsync(user.Id, bookingId);

            if (!success)
                TempData["Error"] = "Unable to cancel booking.";

            return RedirectToAction(nameof(MyBookings));
        }

    }
}
