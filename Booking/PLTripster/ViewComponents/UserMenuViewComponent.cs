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
            return View("Default", user);
        }
    }
}
