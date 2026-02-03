using DATripster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTripster.IServices
{
    public interface IBookingService
    {

        Task<bool> CreateBookingAsync(Booking booking);
        Task<Booking> GetBookingDetailsAsync(int bookingId);
        
    }
}
