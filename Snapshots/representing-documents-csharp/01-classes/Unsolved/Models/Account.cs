using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongodb_classes.Models
{
    internal class Account
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        // Create a new BsonElement below:
        
        public string AccountId { get; set; } = String.Empty;
        // Create a new BsonElement below:
        
        public string AccountHolder { get; set; } = String.Empty;
        // Create a new BsonElement below:
        
        public string AcountType { get; set; } = String.Empty;
        [BsonRepresentation(BsonType.Decimal128)]
        // Create a new BsonElement below:
        
        public decimal Balance { get; set; } 
        // Create a new BsonElement below:
        
        public string[] TransfersComplete { get; set; } = Array.Empty<string>();
    }
}
