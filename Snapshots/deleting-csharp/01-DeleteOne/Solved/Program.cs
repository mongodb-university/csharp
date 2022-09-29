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

 var documentToDelete = Builders<BsonDocument>.Filter.Eq("account_id", "MDB310052894");

// TODO: Create a new variable named `deleteOneResult`:
var deleteOneResult = accountsCollection.DeleteOne(documentToDelete);

 Console.WriteLine(deleteOneResult);
