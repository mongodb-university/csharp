using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using mongodb_classes.Models;

BsonSerializer.RegisterSerializer(new DecimalSerializer(BsonType.Decimal128));

var settings = MongoClientSettings.FromConnectionString("");
var client = new MongoClient(settings);
var database = client.GetDatabase("bank");
var accountsCollection = database.GetCollection<Account>("accounts");
var transfersCollection = database.GetCollection<Transfer>("transfers");

// TODO: Create a new variable named `filter`below:
var filter = Builders<BsonDocument>.Filter.Gt("balance", 4700);
// TODO: Create a new variable named `documents`below:
var documents = accountsCollection.Find(filter).ToList();

foreach (BsonDocument doc in documents)
{
    Console.WriteLine(doc.ToString());
}
