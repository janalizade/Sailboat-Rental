using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Sailboat_Rental.Models
{
    public class Category
    {
        // Convert C# Datatype object to MongoDb Datatype object and vice versa 
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = string.Empty;
        [BsonElement("categoryname")]
        public string CategoryName { get; set; } = string.Empty;
    }
}
