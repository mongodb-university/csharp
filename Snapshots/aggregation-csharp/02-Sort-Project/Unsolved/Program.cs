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

var matchBalanceStage = Builders<Accounts>.Filter.Lt(user => user.Balance, 1500);
var matchAccountStage = Builders<Accounts>.Filter.Eq(user => user.AcountType, "checking");

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