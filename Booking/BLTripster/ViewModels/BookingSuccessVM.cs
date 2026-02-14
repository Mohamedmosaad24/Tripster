using System;

namespace WebTripster.ViewModels
{
    public class BookingSuccessVM
    {
        public int RoomId { get; set; }

        public string HotelName { get; set; } = default!;
        public string HotelAddress { get; set; } = default!;
        public int HotelStars { get; set; } = 3;


        public string RoomType { get; set; } = default!;
        public string MainImageUrl { get; set; } = default!;

     
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

   
        public string CheckInLongDate => CheckIn.ToString("dddd, dd MMMM yyyy");
        public string CheckOutLongDate => CheckOut.ToString("dddd, dd MMMM yyyy");

   
        public decimal TotalPrice { get; set; }
    }
}