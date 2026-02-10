using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTripster.ViewModels
{
    public class RoomVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Room Type")]
        public string RoomType { get; set; } = default!;

        [Required]
        public int Capacity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        [Required]
        [Display(Name = "Hotel")]
        public int HotelId { get; set; }

    }
}
