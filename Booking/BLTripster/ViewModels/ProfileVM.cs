using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTripster.ViewModels
{
    public class ProfileVM
    {
            public string Name { get; set; } 
            public string Email { get; set; }
            public string? Location { get; set; }
            public string? Nationality { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string? ImageUrl { get; set; }

    }
}
