using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATripster.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Location { get; set; }
        public string? Email { get; set; }
        public string? Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public ICollection<Booking> Bookings { get; set; } = default!;
        public ICollection<Review>? Reviews { get; set; }
    }
}
