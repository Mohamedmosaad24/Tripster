using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATripster.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }

        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; } = default!;

        public int? RoomId { get; set; }
        public Room Room { get; set; } = default!;
    }

}
