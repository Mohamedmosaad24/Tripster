using DATripster.Entities;
using System.Collections.Generic;

namespace BLTripster.IServices
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAll();
        Room? GetById(int id);

        void Add(Room room);
        void Update(Room room);
        void Delete(int id);

        void Save();
    }
}