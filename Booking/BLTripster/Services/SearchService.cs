using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLTripster.IServices;
using BLTripster.ViewModels;
using DALTripster.IRepos;
using DATripster.Entities;

namespace BLTripster.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepo _repo;
        public SearchService(ISearchRepo repo)
        {
            _repo = repo;
        }
        public ICollection<Hotel> Search(string destination, DateTime checkIn, DateTime checkOut, int guests)
        {
            return _repo.GetSearch(destination, checkIn, checkOut, guests);

        }
        public ICollection<Hotel> GetAll() => _repo.GetAll();

        public ICollection<Hotel> Filter(string service, int price, int rating)
        {
            return _repo.GetFilter(service, price, rating);
        }
        public ICollection<Hotel> Sort(string sortBy)
        {
            return _repo.Sort(sortBy);

        }
    }
}
