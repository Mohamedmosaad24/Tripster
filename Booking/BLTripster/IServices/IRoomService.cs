using DATripster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTripster.IServices
{
    public interface IRoomService
    {

        Room? GetRoomById(int roomId);
        IEnumerable<Room> GetAllRooms();


    }
}
