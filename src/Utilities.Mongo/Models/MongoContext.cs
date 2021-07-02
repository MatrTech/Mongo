using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace MatrTech.Utilities.Mongo.Models
{
    public class MongoContext : MongoDatabaseBase, IMongoDatabase
    {
        private IMongoDatabase database;

        public MongoContext(IMongoDatabase database)
        {
            this.database = database;
        }

        public override IMongoClient Client => throw new System.NotImplementedException();

        public override DatabaseNamespace DatabaseNamespace => throw new System.NotImplementedException();

        public override MongoDatabaseSettings Settings => throw new System.NotImplementedException();

        public override Task CreateCollectionAsync(string name, CreateCollectionOptions? options = null, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public override Task DropCollectionAsync(string name, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public override IMongoCollection<TResult> GetCollection<TResult>(string name, MongoCollectionSettings? settings = null)
        {
            return this.database.GetCollection<TResult>(name, settings);
        }

        //private IMongoCollection<TDocument> GetCollection<TDocument>(string name, MongoCollectionSettings? settings = null)
        //{
        //    throw new System.NotImplementedException();
        //}

        public override Task<IAsyncCursor<BsonDocument>> ListCollectionsAsync(ListCollectionsOptions? options = null, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public override Task RenameCollectionAsync(string oldName, string newName, RenameCollectionOptions? options = null, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public override Task<TResult> RunCommandAsync<TResult>(Command<TResult> command, ReadPreference? readPreference = null, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}