using BLTripster.IServices;
using DALTripster.IRepos;
using DATripster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTripster.Services
{
    public class ReviewServices : IReviewService
    {
        private readonly IReviewRepo reviewRepo;

        public ReviewServices(IReviewRepo reviewRepo)
        {
            this.reviewRepo = reviewRepo;
        }
        public IEnumerable<Review> GetAll()
        {
            return reviewRepo.GetAll();
        }

        public void RemoveReview(int reviewId)
        {
            reviewRepo.Delete(reviewId);
            reviewRepo.Save();
        }
    }
}
