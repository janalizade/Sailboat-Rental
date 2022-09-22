using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Sailboat_Rental.Model
{
    public class Boat
    {
        // Convert C# Datatype object to MongoDb Datatype object and vice versa 
         
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        
        [BsonElement("number")]
        public string Number { get; set; }=string.Empty;

        [BsonElement("categoryid")]
        public string CategoryId { get; set; } = string.Empty;

        [BsonElement("lessorid")]
        public string LessorId { get; set; } = string.Empty;
    }
}
