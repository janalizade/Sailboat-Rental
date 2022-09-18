using Sailboat_Rental.Models;

namespace SailBoat_Rental.Models
{
    public class AggregatedBooking: Booking
    {
        public String CategoryName { get; set; }
        public float BasicFee { get; set; }
        public float HourlyRate { get; set; }
    }
}
