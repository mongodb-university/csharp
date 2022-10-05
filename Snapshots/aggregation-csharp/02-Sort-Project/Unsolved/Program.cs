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

var matchBalanceStage = Builders<Account>.Filter.Lt(user => user.Balance, 1500);
var matchAccountStage = Builders<Account>.Filter.Eq(user => user.AccountType, "checking");

// TODO: Create a new variable named `projectionStage`below:

var aggregate = accountsCollection.Aggregate()
                           .Match(matchBalanceStage)
                           .Match(matchAccountStage)
                           // TODO: Chain a .SortByDescending() method on the existing Match() function assigned to the aggregate variable and sort based on the balance field.
                           
                           // TODO: Next, chain on a .Project() method and pass in the projectionStage variable as an argument.
                           

var results = aggregate.ToList();

foreach (var account in results)
{
    Console.WriteLine(account.Balance);
}