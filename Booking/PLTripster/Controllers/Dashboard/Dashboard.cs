

using DALTripster.IRepos;
using DATripster.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        private readonly IRepo<Room> _roomRepo;

        public Dashboard(IRepo<Room> roomRepo)
        {
            _roomRepo = roomRepo;
        }

     
        // LIST ROOMS
    
        public IActionResult Rooms()
        {
            var rooms = _roomRepo.GetAll();
            return View(rooms);
        }

        // ADD ROOM (GET)

        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }

        // ADD ROOM (POST)
        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            if (!ModelState.IsValid)
                return View(room);

            _roomRepo.Add(room);
            _roomRepo.Save();

            return RedirectToAction(nameof(Rooms));
        }

        // EDIT ROOM (GET)

        [HttpGet]
        public IActionResult EditRoom(int id)
        {
            var room = _roomRepo.GetById(id);
            if (room == null)
                return NotFound();

            return View(room);
        }


        // EDIT ROOM (POST)
        [HttpPost]
        public IActionResult EditRoom(Room room)
        {
            if (!ModelState.IsValid)
                return View(room);

            _roomRepo.Update(room);
            _roomRepo.Save();

            return RedirectToAction(nameof(Rooms));
        }


        // DELETE ROOM

        public IActionResult DeleteRoom(int id)
        {
            _roomRepo.Delete(id);
            _roomRepo.Save();

            return RedirectToAction(nameof(Rooms));
        }





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
