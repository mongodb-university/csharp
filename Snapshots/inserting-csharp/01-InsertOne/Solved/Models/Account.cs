using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace mongodb_classes.Models
{
    internal class Account
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("account_id")]
        public string AccountId { get; set; } = String.Empty;
        [BsonElement("account_holder")]
        public string AccountHolder { get; set; } = String.Empty;
        [BsonElement("account_type")]
        public string AccountType { get; set; } = String.Empty;
        [BsonRepresentation(BsonType.Decimal128)]
        [BsonElement("balance")]
        public decimal Balance { get; set; } 
        [BsonElement("transfers_complete")]
        public string[] TransfersComplete { get; set; } = Array.Empty<string>();
        [BsonRepresentation(BsonType.String)]
        [BsonElement("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }
    }
}
