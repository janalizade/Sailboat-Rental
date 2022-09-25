using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SailBoat_Rental.Model;
namespace Sailboat_Rental.Model
{
    public class Booking
    {
        
        [BsonId]
       
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


        [BsonElement("categoryId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = string.Empty;

        [BsonElement("returnDate")]
        public DateTime ReturnDate {get; set; }

        [BsonElement("status")]
        public BookingStatus Status { get; set; } = BookingStatus.INUSE;

}
}


