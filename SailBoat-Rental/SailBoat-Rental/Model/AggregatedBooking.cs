using Sailboat_Rental.Model;

namespace SailBoat_Rental.Model
{
    public class AggregatedBooking: Booking
    {
        public String BoatNumber { get; set; }
        public String CategoryName { get; set; }
        public double BasicFee { get; set; }
        public double HourlyRate { get; set; }
    }
}
