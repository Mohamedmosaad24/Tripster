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
    public class HomeService : IHomeService
    {
        private readonly IHomeRepo _repo;

        public HomeService(IHomeRepo repo)
        {
            _repo = repo;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _repo.GetAll().ToList();
        }

    }
}
