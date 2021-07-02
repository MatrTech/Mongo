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

            var result = Activator.CreateInstance(typeof(TContext), database);
            return ((TContext?)result)!;
        }
    }
}