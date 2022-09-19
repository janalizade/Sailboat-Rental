using Sailboat_Rental.Model;

namespace SailBoat_Rental.Model
{
    public class AggregatedBooking: Booking
    {
        public String CategoryName { get; set; }
        public float BasicFee { get; set; }
        public float HourlyRate { get; set; }
    }
}
