namespace BLTripster.ViewModels
{
    public class BookingPageVM
    {
        public string HotelName { get; set; } = string.Empty;
        public string RoomTypeName { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
        public BookingFormVM Form { get; set; } = new();
    }
}
