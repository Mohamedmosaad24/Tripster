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
        public string MainImageUrl { get; set; } = default!;


    }
}
