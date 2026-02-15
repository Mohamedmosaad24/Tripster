using DALTripster.IRepos;
using DATripster.Data;
using DATripster.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTripster.Repos
{
    public class RoomRepository: IRoomRepository
    {
        private readonly TripsterDB _context;

        public RoomRepository(TripsterDB context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms
                .Include(r => r.Hotel)
                .Include(r => r.Images)
                .ToList();
        }


        public Room? GetById(int id)
        {
            return _context.Rooms
                .Include(r => r.Hotel)
                .Include(r => r.Images)
                .FirstOrDefault(r => r.Id == id);
        }




        public void Add(Room entity)
            => _context.Rooms.Add(entity);

        public void Update(Room entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }


        public void Delete(int id)
        {
            var room = GetById(id);
            if (room != null)
                _context.Rooms.Remove(room);
        }

        public void Save()
            => _context.SaveChanges();

        public void AddImageForRoom(int roomId, string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl)) return;
            var room = _context.Rooms.Find(roomId);
            if (room == null) return;
            _context.Images.Add(new Image { RoomId = roomId, HotelId = room.HotelId, ImageUrl = imageUrl.Trim() });
        }

        public void SetFirstImageForRoom(int roomId, string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl)) return;
            var existing = _context.Images.FirstOrDefault(i => i.RoomId == roomId);
            if (existing != null)
            {
                existing.ImageUrl = imageUrl.Trim();
                _context.Entry(existing).State = EntityState.Modified;
            }
            else
            {
                var room = _context.Rooms.Find(roomId);
                if (room != null)
                    _context.Images.Add(new Image { RoomId = roomId, HotelId = room.HotelId, ImageUrl = imageUrl.Trim() });
            }
        }
    }
}




        