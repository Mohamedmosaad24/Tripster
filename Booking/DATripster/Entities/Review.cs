using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATripster.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public float Rate { get; set; }
        public string? Comment { get; set; }
        public int? Cleanliness { get; set; }
        public int? Amenities { get; set; }
        public int? Location { get; set; }
        public int? Comfort { get; set; }
        public int? WiFiConnection { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
