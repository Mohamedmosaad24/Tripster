using BLTripster.IServices;
using BLTripster.ViewModels;
using DALTripster.IRepos;
using DATripster.Entities;
using System.Collections.Generic;

namespace BLTripster.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public Room? GetById(int id)
        {
            return _roomRepository.GetById(id);
        }

        public void Add(Room room)
        {
            _roomRepository.Add(room);
        }

        public void Update(Room room)
        {
            _roomRepository.Update(room);
        }

        public void Delete(int id)
        {
            _roomRepository.Delete(id);
        }


        public void Save()
        {
            _roomRepository.Save();
        }
    }
}