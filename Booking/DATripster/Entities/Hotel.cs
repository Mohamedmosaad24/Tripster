using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATripster.Entities
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; } = default!;
        public string Description { get; set; } = default!;

        // Navigation Properties
        public ICollection<Room> Rooms { get; set; } = default!;
        public ICollection<Image> Images { get; set; } = default!;
        public ICollection<Review> Reviews { get; set; } = default!;
        public ICollection<HotelService> HotelServices { get; set; } = default!;

    }
}
