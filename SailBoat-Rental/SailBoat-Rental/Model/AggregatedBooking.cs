using MongoDB.Bson.Serialization.Attributes;
using Sailboat_Rental.Model;

namespace SailBoat_Rental.Model
{
    public class AggregatedBooking: Booking
    {
        [BsonElement("boatNumber")]
        public String BoatNumber { get; set; }

        [BsonElement("categoryName")]
        public String CategoryName { get; set; }

        [BsonElement("basicFee")]
        public double BasicFee { get; set; }

        [BsonElement("hourlyRate")]
        public double HourlyRate { get; set; }
    }
}
