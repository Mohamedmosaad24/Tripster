using System.ComponentModel.DataAnnotations;

namespace BLTripster.ViewModels
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

        // Display-only; not posted with the form — leave optional so POST validation does not require them
        public string? HotelName { get; set; }
        public string? RoomTypeName { get; set; }
        public decimal PricePerNight { get; set; }
        public string? MainImageUrl { get; set; }


        public decimal CityTax => 40.00m;
        public decimal ServiceFee => 20.00m;

        public decimal GetTotalPrice(int nights)
        {
            return (nights * PricePerNight) + CityTax + ServiceFee;
        }
    }
}
