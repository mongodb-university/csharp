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

// TODO: Create a new variable named matchStage:
var matchStage = Builders<Account>.Filter.Lte(u => u.Balance, 1000);


var aggregate = accountsCollection.Aggregate()
                           .Match(matchStage)
                           // TODO: Add a Group stage:
                           .Group(new BsonDocument { { "_id", "$account_type" }, { "AvgSum", new BsonDocument("$avg", "$balance") } });

var results = aggregate.ToList();

foreach (var account in results)
{
    Console.WriteLine(account.Balance);
}