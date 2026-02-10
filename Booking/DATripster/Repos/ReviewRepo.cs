using DALTripster.IRepos;
using DATripster.Data;
using DATripster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTripster.Repos
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly TripsterDB _context;

        public ReviewRepo(TripsterDB context)
        {
            _context = context;
        }
        public void Add(Review entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
           _context.Reviews.Remove(_context.Reviews.Find(id) ?? throw new InvalidOperationException("Review not found"));
        }

        //get all reviews 
        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews.ToList();

        }

        public Review? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Review entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Review> IRepo<Review>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
