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

var documentsToDelete = Builders<BsonDocument>.Filter.Lt("balance", 5);

// TODO: Create a new variable named `deleteManyResult`:
var deleteManyResult = accountsCollection.DeleteMany(documentsToDelete);

Console.WriteLine("Inserted many documents: {0}", deleteManyResult);
