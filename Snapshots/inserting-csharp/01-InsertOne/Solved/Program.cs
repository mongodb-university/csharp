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

var sampleDocument = new Accounts
    {
        AccountId = "MDB829001337",
        AccountHolder = "Linus Torvalds",
        AcountType = "checking",
        Balance = 50352434
    };


// TODO: Create an expression which inserts a single document into the `accounts` collection below:
accountsCollection.InsertOne(sampleDocument);