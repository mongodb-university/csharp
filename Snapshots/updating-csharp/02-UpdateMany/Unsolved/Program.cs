using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using mongodb_classes.Models;

BsonSerializer.RegisterSerializer(new DecimalSerializer(BsonType.Decimal128));

DotNetEnv.Env.TraversePath().Load();
var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
var settings = MongoClientSettings.FromConnectionString(connectionString);
var client = new MongoClient(settings);
var database = client.GetDatabase("bank");
var accountsCollection = database.GetCollection<Account>("accounts");
var transfersCollection = database.GetCollection<Transfer>("transfers");

var documentsToUpdate = Builders<BsonDocument>.Filter.Lt("balance", 500);
var update = Builders<BsonDocument>.Update.Inc("balance", 10);

// TODO: Create a new variable named `result`:


if (result.IsModifiedCountAvailable)
{
    Console.WriteLine("Number of documents updated: ");
    Console.WriteLine("\t{0}", result.ModifiedCount);
}
