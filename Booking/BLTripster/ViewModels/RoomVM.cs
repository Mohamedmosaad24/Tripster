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
            public string RoomType { get; set; }

            [Required]
            public int Capacity { get; set; }

            [Required]
            public decimal Price { get; set; }

            [Required]
            public int HotelId { get; set; }
            /// <summary>Optional image URL for the room (e.g. https://... or /assets/room.jpg)</summary>
            public string? ImageUrl { get; set; }
        }
    }



