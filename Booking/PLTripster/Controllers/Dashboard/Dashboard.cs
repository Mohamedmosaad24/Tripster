

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CenterSystem.Controllers
{
    public class Dashboard : Controller
    {
        #region Home dashboard
        //Display analysis
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Hotel dashboard
        //HotelRepo : IRepo<Room> =>> implemntation..getall/edit/add/getid/delete

        #endregion

        #region Rooms dashboard
        //RoomsRepo : IRepo<Room> =>> implemntation..getall/edit/add/getid/delete

        #endregion

        #region Bookings dashboard
        //BookingsRepo =>> implemntation  .. Mangement {update}

        #endregion

        #region Reviews dashboard
        //ReviewsRepo =>> GetAll/RemoveReview

        #endregion

        #region Users dashboard
        //UsersRepo =>> GetAll /RemoveUser/ActiveAccount

        #endregion
    }
}
