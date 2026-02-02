using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATripster.Entities;

namespace DALTripster.IRepos
{
    public interface ISearchRepo
    {
        ICollection<Hotel> GetSearch(string destination, DateTime checkIn, DateTime checkOut, int guests);
        ICollection<Hotel> GetAll();
        public ICollection<Hotel> GetFilter(string service, int price, int rating);
        public ICollection<Hotel> Sort(string sortBy);


    }
}
