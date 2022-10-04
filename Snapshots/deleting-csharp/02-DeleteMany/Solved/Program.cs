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

var documentsToDelete = Builders<Account>.Filter.Lt("balance", 5);

// TODO: Create a new variable named `deleteManyResult`:
var deleteManyResult = accountsCollection.DeleteMany(documentsToDelete);

Console.WriteLine("Number of deleted documents: {0}", deleteManyResult.DeletedCount);
