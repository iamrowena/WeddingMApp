using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Bson;
using System;
using System.Collections.ObjectModel;
using WeddingMApp;
using WeddingMApp.Models;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using System.Collections.Generic;

public class MongoDBService
{

    private readonly IMongoClient _client;
    private readonly IMongoDatabase _database;

    public MongoDBService(string connectionString, string databaseName)
    {
        _client = new MongoClient(connectionString);
        _database = _client.GetDatabase(databaseName);
    }

    public async Task<bool> LoginUserAsync(string username, string password)
    {
        var usersCollection = _database.GetCollection<BsonDocument>("TBLCLIENT");

        // Find the user with the given username
        var filter = Builders<BsonDocument>.Filter.Eq("client_no", username);
        var user = await usersCollection.Find(filter).FirstOrDefaultAsync();

        if (user != null)
        {
            // Compare the provided password with the stored password in plain text
            string storedPassword = user["email"].AsString;
            return password == storedPassword;
        }

        return false; // User not found
    }
 

    public async Task<List<TaskModelClass>> GetClientDataAsync(string username)
    {
        var clientDataCollection = _database.GetCollection<BsonDocument>("TBLTASK");

        var filter = Builders<BsonDocument>.Filter.Eq("CLIENTNO", username);
        var documents = await clientDataCollection.Find(filter).ToListAsync();

        var dataList = new List<TaskModelClass>();
        foreach (var document in documents)
        {
            var clientDataItem = new TaskModelClass
            {
                Id = document["_id"].AsObjectId,
                CLIENTNO = document["CLIENTNO"].AsString,
                NAME = document["NAME"].AsString,
                PACKAGE = document["PACKAGE"].AsString,
                SERVICES = document["SERVICES"].AsString,
                WED_DETAILS = document["WED_DETAILS"].AsString,
                // Add other property assignments as needed
            };
            dataList.Add(clientDataItem);
        }
        return dataList;
    }


    public async Task<List<AppModelClass>> AppDataAsync(string username)
    {
        var AppDataCollection = _database.GetCollection<BsonDocument>("TBLAPPOINTMENTS");

        var filter = Builders<BsonDocument>.Filter.Eq("CLIENTNO", username);
        var documents = await AppDataCollection.Find(filter).ToListAsync();

        var AppList = new List<AppModelClass>();
        foreach (var document in documents)
        {
            var AppDataItem = new AppModelClass
            {
                Id = document["_id"].AsObjectId,
                CLIENTNO = document["CLIENTNO"].AsString,
                NAME = document["NAME"].AsString,
                CONTACT = document["CONTACT"].AsString,
                DATE = document["DATE"].AsString,
                TIME = document["TIME"].AsString,
                SUBJECT = document["SUBJECT"].AsString,
                DESCRIPTION = document["DESCRIPTION"].AsString,
                // Add other property assignments as needed
            };
            AppList.Add(AppDataItem);
        }
        return AppList;
    }




}



