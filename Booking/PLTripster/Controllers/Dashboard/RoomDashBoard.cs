using BLTripster.IServices;
using DATripster.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PLTripster.Controllers.Dashboard
{
    public class RoomDashBoard : Controller
    {
        private readonly IRoomService _roomService;

        public RoomDashBoard(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // LIST ROOMS
        public IActionResult Rooms()
        {
            var rooms = _roomService.GetAll();
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

            _roomService.Add(room);
            _roomService.Save();

            return RedirectToAction(nameof(Rooms));
        }

        // EDIT ROOM (GET)
        [HttpGet]
        public IActionResult EditRoom(int id)
        {
            var room = _roomService.GetById(id);
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

            _roomService.Update(room);
            _roomService.Save();

            return RedirectToAction(nameof(Rooms));
        }

        // DELETE ROOM
        public IActionResult DeleteRoom(int id)
        {
            _roomService.Delete(id);
            _roomService.Save();

            return RedirectToAction(nameof(Rooms));
        }
    }
}

