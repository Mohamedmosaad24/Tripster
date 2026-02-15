using DATripster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTripster.IRepos
{
    public interface IRoomRepository : IRepo<Room>
    {
        void AddImageForRoom(int roomId, string imageUrl);
        void SetFirstImageForRoom(int roomId, string imageUrl);
    }
}







