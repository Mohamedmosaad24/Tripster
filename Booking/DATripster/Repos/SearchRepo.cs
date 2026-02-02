using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALTripster.IRepos;
using DATripster.Data;
using DATripster.Entities;
using Microsoft.EntityFrameworkCore;

namespace DALTripster.Repos
{
    public class SearchRepo : ISearchRepo
    {
        private readonly TripsterDB db;
        public SearchRepo(TripsterDB db)
        {
            this.db=db;
        }

        public ICollection<Hotel> GetAll()
        {
                        var query = db.Hotels
                .AsNoTracking()
                .Include(h => h.Rooms)
                .ThenInclude(r => r.Bookings)
                .Include(h => h.Reviews)
                .Include(h => h.HotelServices)
                .Include(h => h.Images)
                .AsQueryable();
            return query.ToList();
        }
        public ICollection<Hotel> Sort(string sortBy)
        {
            var query = db.Hotels
                .AsNoTracking()
                .Include(h => h.Rooms)
                .ThenInclude(r => r.Bookings)
                .Include(h => h.Reviews)
                .Include(h => h.HotelServices)
                .Include(h => h.Images)
                .AsQueryable();

            if (sortBy == "price")
            {
                query = query.OrderByDescending(h => h.Rooms.Any() ? h.Rooms.Max(r => r.Price) : 0);

            }
            else if (sortBy == "rate") 
            {
                query = query.OrderByDescending(h => h.Reviews.Any() ? h.Reviews.Average(r => r.Rate) : 0);
            }

            return query.ToList();

        }

        public ICollection<Hotel> GetSearch(string destination, DateTime checkIn, DateTime checkOut, int guests)
        {
            var query = db.Hotels
                .AsNoTracking()
                .Include(h => h.Rooms)
                    .ThenInclude(r => r.Bookings)
                .Include(h => h.Reviews)
                .Include(h => h.HotelServices)
                .Include(h => h.Images)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(destination))
            {
                query = query.Where(h => h.Address.ToLower().Contains(destination.ToLower()));
            }

            query = query.Where(h => h.Rooms.Any(h => h.Capacity >= guests &&
            !h.Bookings.Any(b => checkIn < b.CheckOut && checkOut > b.CheckIn)));

            return query.ToList();
        }
        public ICollection<Hotel> GetFilter(string service, int price, int rating)
        {
            var query = db.Hotels
                .AsNoTracking()
                .Include(h => h.Rooms)
                    .ThenInclude(r => r.Bookings)
                .Include(h => h.Reviews)
                .Include(h => h.HotelServices)
                    .ThenInclude(hs => hs.Service)
                .Include(h => h.Images)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(service))
            {
                query = query.Where(h => h.HotelServices.Any(hs => hs.Service.Name == service));
            }

            if (price > 0)
            {
                query = query.Where(h => h.Rooms.Any(r => r.Price >= price));
            }

            if (rating > 0)
            {
                query = query.Where(h => h.Reviews.Any() && h.Reviews.Average(r => r.Rate) >= rating);
            }

            return query.ToList();
        }

    }
}
