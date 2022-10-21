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

using (var session = client.StartSession())
{

    // TODO: Replace `<method>` with your answer below:
    session.<method>(
        (s, ct) =>
        {
            var fromId = "MDB574189300";
            var toId = "MDB343652528";

            // Create the transfer_id and amount being transfered
            var transferId = "TR02081994";
            var transferAmount = 20;

            // Obtain the account the money will be coming from
            var fromAccountResult = accountsCollection.Find(e => e.AccountId == fromId).FirstOrDefault();
            // Get the balance and id that the money will be coming from
            var fromAccountBalance = fromAccountResult.Balance - transferAmount;
            var fromAccountId = fromAccountResult.AccountId;

            // Obtain the account the money will be going 
            var toAccountResult = accountsCollection.Find(e => e.AccountId == toId).FirstOrDefault();
            // Get the balance and id that the money will be going too
            var toAccountBalance = toAccountResult.Balance + transferAmount;
            var toAccountId = toAccountResult.AccountId;

            // Create the transfer record
            var transferDocument = new Transfer
            {
                TransferId = transferId,
                ToAccount = toAccountId,
                FromAccount = fromAccountId,
                Amount = transferAmount,
                LastUpdated = DateTimeOffset.UtcNow
            };

            // Update the balance and transfer array for each account
            var fromAccountUpdateBalance = Builders<Account>.Update.Set("balance", fromAccountBalance);
            var fromAccountFilter = Builders<Account>.Filter.Eq("account_id", fromId);
            accountsCollection.UpdateOne(fromAccountFilter, fromAccountUpdateBalance);

            var fromAccountUpdateTransfers = Builders<Account>.Update.Push("transfers_complete", transferId);
            accountsCollection.UpdateOne(fromAccountFilter, fromAccountUpdateTransfers);

            var toAccountUpdateBalance = Builders<Account>.Update.Set("balance", toAccountBalance);
            var toAccountFilter = Builders<Account>.Filter.Eq("account_id", toId);
            accountsCollection.UpdateOne(toAccountFilter, toAccountUpdateBalance);
            var toAccountUpdateTransfers = Builders<Account>.Update.Push("transfers_complete", transferId);
            accountsCollection.UpdateOne(toAccountFilter, toAccountUpdateTransfers);

            // Insert transfer doc
            transfersCollection.InsertOne(transferDocument);
            Console.WriteLine("Transaction complete!");
            return "Inserted into collections in different databases";
        });
}
