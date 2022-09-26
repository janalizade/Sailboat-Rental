using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Sailboat_Rental.Model
{
    public class Boat
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        
        [BsonElement("number")]
        public string Number { get; set; }=string.Empty;

        [BsonElement("categoryid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = string.Empty;

        [BsonElement("lessorid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string LessorId { get; set; } = string.Empty;
    }
}
