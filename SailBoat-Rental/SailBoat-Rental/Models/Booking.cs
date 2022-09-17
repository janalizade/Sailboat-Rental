using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SailBoat_Rental.Models;
namespace Sailboat_Rental.Models
{
    public class Booking
    {
        // Convert C# Datatype object to MongoDb Datatype object and vice versa 
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("number")]
        public int Number { get; set; }

        [BsonElement("handoverDate")]
        public DateTime HandoverDate { get; set; }

        [BsonElement("personNumber")]
        public string PersonNumber { get; set; } = string.Empty;

        [BsonElement("boatId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BoatId { get; set; } = string.Empty;


        [BsonElement("lessorId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string LessorId { get; set; }= string.Empty;
        
          
        [BsonElement("returnDate")]
        public DateTime ReturnDate {get; set; }

        [BsonElement("status")]
        public BookingStatus Status { get; set; } = BookingStatus.INPROGRESS;

}
}
