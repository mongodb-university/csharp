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

var accountA = new Account
{
    AccountId = "MDB011235813",
    AccountHolder = "Ada Lovelace",
    AccountType = "checking",
    Balance = 60218
};

var accountB = new Account
{
    AccountId = "MDB829000001",
    AccountHolder = "Muhammad ibn Musa al-Khwarizmi",
    AccountType = "savings",
    Balance = 267914296
};

// TODO: Create an expression which inserts multiple documents into the `accounts` collection below:
accountsCollection.InsertMany(new List<Account>() { accountA, accountB });