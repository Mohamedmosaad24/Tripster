using DALTripster.Entities;
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
    public class HomeRepo : IHomeRepo
    {
        private readonly TripsterDB _db;
        public HomeRepo(TripsterDB db)
        {
            _db = db;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _db.Hotels
                .Include(h => h.Images)
                .Include(h => h.Rooms)
                .Include(h => h.Reviews)
                .ToList();
        }
        public void Add(Home entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Home? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Home entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Home> IRepo<Home>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
