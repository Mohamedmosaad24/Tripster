using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLTripster.ViewModels;
using DATripster.Entities;

namespace BLTripster.IServices
{
    public interface ISearchService
    {
        public ICollection<Hotel> Search(string destination, DateTime checkIn, DateTime checkOut, int guests);
     public ICollection<Hotel> GetAll();
     public ICollection<Hotel> Filter(string service, int price, int rating);
        public ICollection<Hotel> Sort(string sortBy);


    }
}
