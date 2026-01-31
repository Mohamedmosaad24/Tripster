using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATripster.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomType { get; set; } = default!;
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } = default!;

        public ICollection<Image>? Images { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
