using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Sailboat_Rental.Models
{
    public class Lessor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }=String.Empty;
        
        [BsonElement("name")]
        public string Name { get; set; }=String.Empty;
        
        [BsonElement("address")]
        public string Address { get; set; }=String.Empty;

    }
}
