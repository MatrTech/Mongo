using MatrTech.Utilities.Helpers;
using MatrTech.Utilities.Mongo.Models;
using MongoDB.Driver;
using System;

namespace MatrTech.Utilities.Mongo
{
    public class DatabaseManager
    {
        public static TContext Create<TContext>(string connectionUrl, string databaseName)
            where TContext : MongoContext
        {
            var client = new MongoClient(connectionUrl);
            IMongoDatabase database = client.GetDatabase(databaseName) ?? throw new NullReferenceException();

            var result = ActivatorHelper.CreateInstance<TContext>(database);
            return result!;
        }
    }
}