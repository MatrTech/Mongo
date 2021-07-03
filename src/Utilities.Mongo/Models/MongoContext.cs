using MatrTech.Utilities.Extensions.Mongo;
using MatrTech.Utilities.Mongo.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace MatrTech.Utilities.Mongo.Models
{
    public abstract class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase database;

        public bool CollectionExists(string collectionName)
            => database.CollectionExists(collectionName);

        public Task<bool> CollectionExistsAsync(string collectionName)
        {
            throw new System.NotImplementedException();
        }
    }
}