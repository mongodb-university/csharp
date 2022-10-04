using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongodb_classes.Models
{
    internal class Transfer
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("transfer_id")]
        public string TransferId { get; set; } = String.Empty;
        [BsonElement("to_account")]
        public string ToAccount { get; set; } = String.Empty;
        [BsonElement("from_account")]
        public string FromAccount { get; set; } = String.Empty;
        [BsonElement("amount")]
        public int Amount { get; set; }
        [BsonElement("memo")]
        public string Memo { get; set; } = String.Empty;
        [BsonRepresentation(BsonType.String)]
        [BsonElement("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }
    }
}