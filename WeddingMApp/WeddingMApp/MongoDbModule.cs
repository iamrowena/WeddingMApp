using MongoDB.Bson;
using MongoDB.Driver;
using System;

public static class MongoDbModule
{
    private static string connectionString = "mongodb://WeddingManagement:DBWEDDING@ac-wqpfbrf-shard-00-00.npbib6e.mongodb." +
        "net:27017,ac-wqpfbrf-shard-00-01.npbib6e.mongodb.net:27017,ac-wqpfbrf-shard-00-02.npbib6e.mongodb.net:27017/?ssl=" +
        "true&replicaSet=atlas-dakj1p-shard-0&authSource=admin&retryWrites=true&w=majority";


    private static IMongoClient client;
    private static IMongoDatabase database;

    public static void InitializeMongoDb()
    {
        client = new MongoClient(connectionString);
        database = client.GetDatabase("DBWEDDING");// ito palitan mo ng name ng database mo
    }

    public static IMongoCollection<BsonDocument> GetCollection(string collectionName)
    {
        return database.GetCollection<BsonDocument>(collectionName);
    }


}
