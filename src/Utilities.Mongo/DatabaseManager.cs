using MatrTech.Utilities.Mongo.Models;
using MongoDB.Driver;

namespace MatrTech.Utilities.Mongo
{
    public class DatabaseManager
    {
        public static IMongoDatabase Create<TContext>(string databaseConfigName)
            where TContext : MongoContext
        {
            var client = new MongoClient("");
            return client.GetDatabase(databaseConfigName);
        }
    }
}
