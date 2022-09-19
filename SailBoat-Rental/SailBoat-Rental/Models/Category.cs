using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Sailboat_Rental.Models
{
    public class Category
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = string.Empty;
        
        [BsonElement("categoryname")]
        [Required(ErrorMessage = "Name Is Required")]
        public string CategoryName { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;
    }

  
}
