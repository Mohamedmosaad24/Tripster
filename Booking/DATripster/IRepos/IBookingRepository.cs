using DATripster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTripster.IRepos
{
    public interface IBookingRepository
    {
        public Task<int> AddBookingAsync(Booking booking);
        public Task<Booking> GetBookingByIdAsync(int id);
        public Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId);
        Task<IEnumerable<Booking>> GetAllWithDetailsAsync();
    }
}
