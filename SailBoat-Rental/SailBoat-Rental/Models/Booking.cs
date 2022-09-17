using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Sailboat_Rental.Models
{
    public class Booking
    {
        // Convert C# Datatype object to MongoDb Datatype object and vice versa 
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BookingNumber { get; set; } = string.Empty;
        [BsonElement("customerid")]
        public string CustomerId { get; set; } = string.Empty;
        [BsonElement("lessorid")]
        public string LessorId { get; set; }= string.Empty;
        [BsonElement("rentalperiod")]
        public int? RentalPeriod { get; set; }
        [BsonElement("rentalhours")]
        public int? RentalHours { get; set; }
        [BsonElement("handover")]
        public DateTime Handover { get; set; }
        [BsonElement("rentalreturn")]
        public DateTime Rentalreturn {get; set; }


    }
}
