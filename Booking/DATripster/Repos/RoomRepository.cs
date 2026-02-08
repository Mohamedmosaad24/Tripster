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
            => _context.Rooms.ToList();

        public Room? GetById(int id)
            => _context.Rooms.FirstOrDefault(r => r.Id == id);

        public void Add(Room entity)
            => _context.Rooms.Add(entity);

        public void Update(Room entity)
            => _context.Rooms.Update(entity);

        public void Delete(int id)
        {
            var room = GetById(id);
            if (room != null)
                _context.Rooms.Remove(room);
        }

        public void Save()
            => _context.SaveChanges();
    }
}




        