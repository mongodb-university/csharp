using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
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

 var documentToDelete = Builders<Account>.Filter.Eq("account_id", "MDB905411541");

// TODO: Create a new variable named `deleteOneResult`:
var deleteOneResult = accountsCollection.DeleteOne(documentToDelete);

 Console.WriteLine("Number of deleted documents: {0}", deleteOneResult.DeletedCount);
