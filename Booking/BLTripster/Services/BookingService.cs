
using BLTripster.IServices;
using DALTripster.IRepos;
using DATripster.Entities;
using DATripster.Repositories;
using System;
using System.Threading.Tasks;

namespace BLTripster.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;

        public BookingService(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public async Task<bool> CreateBookingAsync(Booking booking)
        {
            
            if (!booking.CheckIn.HasValue || !booking.CheckOut.HasValue)
                return false;

            if (booking.CheckIn.Value < DateTime.Now.Date)
                return false; 

            if (booking.CheckIn.Value >= booking.CheckOut.Value)
                return false; 

       
            int totalNights = (booking.CheckOut.Value - booking.CheckIn.Value).Days;

            decimal pricePerNight = 180m;
            decimal cityTax = 40m;
            decimal serviceFee = 20m;

            booking.TotalPrice = (totalNights * pricePerNight) + cityTax + serviceFee;

            int resultId = await _bookingRepo.AddBookingAsync(booking);

          
            return resultId > 0;
        }
    }
}