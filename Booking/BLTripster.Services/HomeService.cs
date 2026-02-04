using BLTripster.IServices;
using DALTripster.IRepos;
using System.Collections.Generic;

namespace BLTripster.Services
{
    public class HomeService : IHomeService
    {
        private readonly ISearchRepo _repo;

        public HomeService(ISearchRepo repo)
        {
            _repo = repo;
        }

        public ICollection<Hotel> GetAll()
        {
            return _repo.GetAllHotels();
        }
    }
}