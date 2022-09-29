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

// TODO: Complete the `Find()` query so that it returns the first document in the `accounts` collection with `AccountId` of `MDB773154309` using LINQ below:
var firstDocument = accountsCollection.Find(account => account.AccountId == "MDB773154309").FirstOrDefault();

Console.WriteLine(firstDocument.ToString());