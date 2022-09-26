namespace SailBoat_Rental.Model
{
    public class BookQueryStringModel
    {
        
        public string bookNumber { get; set; } = string.Empty;
        public string personNumber { get; set; } = string.Empty;
        public BookingStatus bookingStatus { get; set; } = BookingStatus.UNDEFINED;
    }
}
