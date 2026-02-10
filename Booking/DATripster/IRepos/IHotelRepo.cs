using DATripster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTripster.IRepos
{
    public interface IHotelRepo : IRepo<Hotel>
    {
        void DeleteImg(int id);
    }
}
