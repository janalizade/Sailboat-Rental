namespace SailBoat_Rental.Model
{
    public class BookingRegistration
    {
        public string BookingNumber { get; set; } = string.Empty;
        public DateTime HandoverDate { get; set; } = DateTime.Now;
        public string PersonNumber { get; set; } = string.Empty;
    }
}
