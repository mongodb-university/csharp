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

var documentToUpdate = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId("62d6e04ecab6d8e130497482"));
var update = Builders<BsonDocument>.Update.Inc("balance", 100);

// TODO: Create a new variable named `result`:
var result = accountsCollection.UpdateOne(documentToUpdate, update);

if (result.IsModifiedCountAvailable)
{
    Console.WriteLine("Number of document updated:\n\t{result.ModifiedCount");
}
