using BLTripster.IServices;
using DALTripster.IRepos;
using DATripster.Entities;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            return await _bookingRepo.GetAllWithDetailsAsync();
        }

        public async Task<int> CreateBookingAsync(Booking booking)
        {
            if (!booking.CheckIn.HasValue || !booking.CheckOut.HasValue)
                return 0;

            if (booking.CheckIn.Value < DateTime.Now.Date)
                return 0;

            if (booking.CheckIn.Value >= booking.CheckOut.Value)
                return 0;

            int totalNights = (booking.CheckOut.Value - booking.CheckIn.Value).Days;

            decimal pricePerNight = 180m;
            decimal cityTax = 40m;
            decimal serviceFee = 20m;

            booking.TotalPrice = (totalNights * pricePerNight) + cityTax + serviceFee;

            return await _bookingRepo.AddBookingAsync(booking);
        }

        public async Task<Booking?> GetBookingDetailsAsync(int bookingId)
        {
            return await _bookingRepo.GetBookingByIdAsync(bookingId);
        }
    }
}