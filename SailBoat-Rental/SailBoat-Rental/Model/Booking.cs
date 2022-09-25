using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SailBoat_Rental.Model;
namespace Sailboat_Rental.Model
{
    public class Booking
    {
        public Booking()
        {

        }

        public Booking(string LessorId, string categoryId, string boatId, string BookingNumber, string PersonNumber, DateTime HandoverDate)
        {
            this.LessorId = LessorId;
            this.CategoryId = categoryId;
            this.BoatId = boatId;
            this.BookingNumber = BookingNumber;
            this.PersonNumber = PersonNumber;
            this.HandoverDate = HandoverDate;
        }



        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("bookingNumber")]
        public string BookingNumber { get; set; } = string.Empty;

        [BsonElement("handoverDate")]
        public DateTime HandoverDate { get; set; }

        [BsonElement("personNumber")]
        public string PersonNumber { get; set; } = string.Empty;

        [BsonElement("boatId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BoatId { get; set; } = string.Empty;

        [BsonElement("lessorId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string LessorId { get; set; } = string.Empty;


        [BsonElement("categoryId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = string.Empty;

        [BsonElement("returnDate")]
        public DateTime ReturnDate { get; set; }

        [BsonElement("status")]
        public BookingStatus Status { get; set; } = BookingStatus.INUSE;

        [BsonElement("price")]
        public double Price { get; set; }

    }
}


