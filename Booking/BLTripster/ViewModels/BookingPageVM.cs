using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTripster.ViewModels;

namespace BLTripster.ViewModels
{
    public class BookingPageVM
    {
        public BookingFormVM Form { get; set; } = new();

        public string HotelName { get; set; } = default!;
        public string RoomTypeName { get; set; } = default!;
        public decimal PricePerNight { get; set; }
        public string? MainImageUrl { get; set; } = default!;
        //public int RoomId { get; set; }
        //public int UserId { get; set; }

        //public DateTime? CheckIn { get; set; }
        //public DateTime? CheckOut { get; set; }

        //public string GuestFullName { get; set; } = string.Empty;
        //public string GuestEmail { get; set; } = string.Empty;
        //public string GuestPhone { get; set; } = string.Empty;

    }
}
