using System.ComponentModel.DataAnnotations;

namespace WebTripster.ViewModels
{
    public class BookingFormVM
    {
      
        [Required(ErrorMessage = "Please select a check-in date")]
        public DateTime? CheckIn { get; set; }

        [Required(ErrorMessage = "Please select a check-out date")]
        public DateTime? CheckOut { get; set; }

        public int RoomId { get; set; }
        public int UserId { get; set; }

     
        [Required]
        public string GuestFullName { get; set; } = default!;
        [EmailAddress]
        public string GuestEmail { get; set; } = default!;
        public string GuestPhone { get; set; } = default!;


       
        public string HotelName { get; set; } = "Hotel Norrebro";
        public string RoomTypeName { get; set; } = "Standard double room";
        public decimal PricePerNight { get; set; } = 180.00m;
        public string MainImageUrl { get; set; } = default!;


        public decimal CityTax => 40.00m;
        public decimal ServiceFee => 20.00m;

        public decimal GetTotalPrice(int nights)
        {
            return (nights * PricePerNight) + CityTax + ServiceFee;
        }
    }
}
