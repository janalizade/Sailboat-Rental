using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Sailboat_Rental.Models
{
    public class Category
    {
        // Convert C# Datatype object to MongoDb Datatype object and vice versa 
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = string.Empty;
        [BsonElement("categoryname")]
        [MongoUniqueStringIndex]
        [Required(ErrorMessage = "Name Is Required")]
        public string CategoryName { get; set; } = string.Empty;
    }

    internal class MongoUniqueStringIndexAttribute : Attribute
    {
    }
}
