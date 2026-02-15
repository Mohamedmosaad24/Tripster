using DALTripster.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PLTripster.ViewComponents
{
    public class UserMenuViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserMenuViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!HttpContext.User.Identity?.IsAuthenticated ?? true)
                return View("Default", (ApplicationUser?)null);

            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.IsAdmin = user != null && await _userManager.IsInRoleAsync(user, "Admin");
            return View("Default", user);
        }
    }
}
