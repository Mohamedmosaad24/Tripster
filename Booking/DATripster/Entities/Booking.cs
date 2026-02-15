using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATripster.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public decimal TotalPrice { get; set; }

        public string GuestFullName { get; set; } = string.Empty;
        public string GuestEmail { get; set; } = string.Empty;
        public string GuestPhone { get; set; } = string.Empty;

        public int RoomId { get; set; }
        public Room Room { get; set; } = default!;

        public int UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
