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
            var query = db.Hotels
                .AsNoTracking()
                .Include(h => h.Rooms)
                .ThenInclude(r => r.Bookings)
                .Include(h => h.Rooms)
                .ThenInclude(r => r.Images)
                .Include(h => h.Reviews)
                .Include(h => h.HotelServices)
                .ThenInclude(h=>h.Service)
                .Include(h => h.Images)
                .AsQueryable().FirstOrDefault(h => h.Id == id);
            return query;
        }
        public void Add(Hotel entity)
        {
            db.Hotels.Add(entity);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var hotel = new Hotel { Id = id };

            db.Hotels.Attach(hotel);
            db.Hotels.Remove(hotel);

            db.SaveChanges();
        }

        public IEnumerable<Hotel> GetAll()
        {
           return db.Hotels.ToList();
        }


        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteImg(int id)
        {
            var images = db.Images.Where(i => i.HotelId == id).ToList();

            foreach (var img in images)
            {
                db.Images.Remove(img);
            }

            db.SaveChanges();

        }
    }
}
