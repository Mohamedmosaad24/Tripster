using DALTripster.IRepos;
using DATripster.Data;
using DATripster.Entities;
using Microsoft.EntityFrameworkCore;

namespace DALTripster.Repos
{
    public class BookingRepository : IBookingRepository
    {
        private TripsterDB _context;
        public BookingRepository(TripsterDB context)
        {
            _context = context;
        }

        public async Task<int> AddBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking.Id;
        }

        public async Task<IEnumerable<Booking>> GetAllWithDetailsAsync()
        {
            return await _context.Bookings
                                .Include(b => b.Room)
                                .ThenInclude(r => r.Hotel)
                                .Include(u => u.User)
                                .OrderByDescending(b => b.Id)
                                .ToListAsync();
        }

        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.Room)
                    .ThenInclude(r => r.Hotel)
                .Include(b => b.Room)
                    .ThenInclude(r => r.Images)
                .FirstOrDefaultAsync(b => b.Id == id);
        }


        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId)
        {
            return await Task.FromResult(new List<Booking>());
        }
    }
}