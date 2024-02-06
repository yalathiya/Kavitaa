using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kavitaa.Connection
{
    public static class Connect
    {
        private static IMongoDatabase _database;

        static Connect()
        {
            // MongoDB connection details
            string connectionString = "mongodb+srv://yash_freecodecamp:yash_freecodecamp@cluster0.htzrrjd.mongodb.net/?retryWrites=true&w=majority";
            string databaseName = "kavita";

            // Create a MongoClient
            MongoClient client = new MongoClient(connectionString);

            // Access the specified database
            _database = client.GetDatabase(databaseName);
        }

        // Create a method to get a collection from the database
        public static IMongoCollection<TDocument> GetCollection<TDocument>(string collectionName)
        {
            return _database.GetCollection<TDocument>(collectionName);
        }
    }
}