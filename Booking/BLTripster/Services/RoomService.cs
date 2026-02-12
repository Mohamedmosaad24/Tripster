using BLTripster.IServices;
using BLTripster.ViewModels;
using DALTripster.IRepos;
using DATripster.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
            
            var existingRoom = _roomRepository.GetById(room.Id);

            if (existingRoom != null)
            {
                existingRoom.RoomType = room.RoomType;
                existingRoom.Capacity = room.Capacity;
                existingRoom.Price = room.Price;
                existingRoom.IsAvailable = room.IsAvailable;
                if (room.HotelId != 0)
                {
                    existingRoom.HotelId = room.HotelId;
                }
                _roomRepository.Update(existingRoom);
            }
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

