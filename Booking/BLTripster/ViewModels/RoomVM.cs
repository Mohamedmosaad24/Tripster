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

       
        [Display(Name = "Room Type")]
        public string RoomType { get; set; } = default!;

      
        public int Capacity { get; set; }

      
        public decimal Price { get; set; }

        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        
        [Display(Name = "Hotel")]
        [Required(ErrorMessage = "Please select a hotel")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Hotel selection")] 
        public int HotelId { get; set; }

    }
}
