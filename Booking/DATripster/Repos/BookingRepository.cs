using DALTripster.IRepos;
using DATripster.Entities;

namespace DATripster.Repositories
{
    public class BookingRepository : IBookingRepository
    {


        public async Task<int> AddBookingAsync(Booking booking)
        {
            

            return await Task.FromResult(1); 
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await Task.FromResult(new Booking()); 
        }

        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId)
        {
            return await Task.FromResult(new List<Booking>()); 
        }
    }
}