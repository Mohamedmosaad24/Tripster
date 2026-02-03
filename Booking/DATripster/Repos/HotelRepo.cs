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
    public class HotelRepo : IHotelRepo
    {

        private readonly TripsterDB db;
        public HotelRepo(TripsterDB db)
        {
            this.db = db;
        }
        public Hotel? GetById(int id)
        {
                return db.Hotels
                  .Include(h => h.Images)
                  .Include(h => h.Reviews)
                  .ThenInclude(r => r.User)
                  .Include(h => h.Rooms)
                      .ThenInclude(r => r.Images)
                  .Include(h => h.HotelServices)
                      .ThenInclude(hs => hs.Service)
                  .FirstOrDefault(h => h.Id == id);
        }
        public void Add(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hotel> GetAll()
        {
            throw new NotImplementedException();
        }


        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Hotel entity)
        {
            throw new NotImplementedException();
        }

      
    }
}
