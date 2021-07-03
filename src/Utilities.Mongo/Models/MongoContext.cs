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

        public MongoContext(IMongoDatabase database)
        {
            //this.client = new MongoClient();
            this.database = database;
        }

        public IMongoClient Client => database.Client;

        public DatabaseNamespace DatabaseNamespace => database.DatabaseNamespace;

        public MongoDatabaseSettings Settings => throw new System.NotImplementedException();

        public IAsyncCursor<TResult> Aggregate<TResult>(
            PipelineDefinition<NoPipelineInput, TResult> pipeline,
            AggregateOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public IAsyncCursor<TResult> Aggregate<TResult>(
            IClientSessionHandle session,
            PipelineDefinition<NoPipelineInput, TResult> pipeline,
            AggregateOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IAsyncCursor<TResult>> AggregateAsync<TResult>(
            PipelineDefinition<NoPipelineInput, TResult> pipeline,
            AggregateOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IAsyncCursor<TResult>> AggregateAsync<TResult>(
            IClientSessionHandle session,
            PipelineDefinition<NoPipelineInput, TResult> pipeline,
            AggregateOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public void AggregateToCollection<TResult>(
            PipelineDefinition<NoPipelineInput, TResult> pipeline,
            AggregateOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public void AggregateToCollection<TResult>(
            IClientSessionHandle session,
            PipelineDefinition<NoPipelineInput, TResult> pipeline,
            AggregateOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task AggregateToCollectionAsync<TResult>(
            PipelineDefinition<NoPipelineInput, TResult> pipeline,
            AggregateOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task AggregateToCollectionAsync<TResult>(
            IClientSessionHandle session,
            PipelineDefinition<NoPipelineInput, TResult> pipeline,
            AggregateOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public bool CollectionExists(string collectionName)
            => database.CollectionExists(collectionName);

        public Task<bool> CollectionExistsAsync(string collectionName)
        {
            throw new System.NotImplementedException();
        }

        public void CreateCollection(string name, CreateCollectionOptions? options = null, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public void CreateCollection(
            IClientSessionHandle session,
            string name,
            CreateCollectionOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateCollectionAsync(string name, CreateCollectionOptions? options = null, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateCollectionAsync(
            IClientSessionHandle session,
            string name,
            CreateCollectionOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public void CreateView<TDocument, TResult>(
            string viewName,
            string viewOn,
            PipelineDefinition<TDocument, TResult> pipeline,
            CreateViewOptions<TDocument>? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public void CreateView<TDocument, TResult>(
            IClientSessionHandle session,
            string viewName,
            string viewOn,
            PipelineDefinition<TDocument, TResult> pipeline,
            CreateViewOptions<TDocument>? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateViewAsync<TDocument, TResult>(
            string viewName,
            string viewOn,
            PipelineDefinition<TDocument, TResult> pipeline,
            CreateViewOptions<TDocument>? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateViewAsync<TDocument, TResult>(
            IClientSessionHandle session,
            string viewName,
            string viewOn,
            PipelineDefinition<TDocument, TResult> pipeline,
            CreateViewOptions<TDocument>? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public void DropCollection(string name, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public void DropCollection(IClientSessionHandle session, string name, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task DropCollectionAsync(string name, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task DropCollectionAsync(IClientSessionHandle session, string name, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>(string name, MongoCollectionSettings? settings = null)
            => database.GetCollection<TDocument>(name, settings);

        public IAsyncCursor<string> ListCollectionNames(ListCollectionNamesOptions? options = null, CancellationToken cancellationToken = default)
        {
            return database.ListCollectionNames(options, default);
        }

        public IAsyncCursor<string> ListCollectionNames(
            IClientSessionHandle session,
            ListCollectionNamesOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IAsyncCursor<string>> ListCollectionNamesAsync(ListCollectionNamesOptions? options = null, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IAsyncCursor<string>> ListCollectionNamesAsync(
            IClientSessionHandle session,
            ListCollectionNamesOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public IAsyncCursor<BsonDocument> ListCollections(ListCollectionsOptions? options = null, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public IAsyncCursor<BsonDocument> ListCollections(
            IClientSessionHandle session,
            ListCollectionsOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IAsyncCursor<BsonDocument>> ListCollectionsAsync(
            ListCollectionsOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IAsyncCursor<BsonDocument>> ListCollectionsAsync(
            IClientSessionHandle session,
            ListCollectionsOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public void RenameCollection(string oldName, string newName, RenameCollectionOptions? options = null, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public void RenameCollection(
            IClientSessionHandle session,
            string oldName,
            string newName,
            RenameCollectionOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task RenameCollectionAsync(string oldName, string newName, RenameCollectionOptions? options = null, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task RenameCollectionAsync(
            IClientSessionHandle session,
            string oldName,
            string newName,
            RenameCollectionOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public TResult RunCommand<TResult>(Command<TResult> command, ReadPreference? readPreference = null, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public TResult RunCommand<TResult>(
            IClientSessionHandle session,
            Command<TResult> command,
            ReadPreference? readPreference = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> RunCommandAsync<TResult>(
            Command<TResult> command,
            ReadPreference? readPreference = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> RunCommandAsync<TResult>(
            IClientSessionHandle session,
            Command<TResult> command,
            ReadPreference? readPreference = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public IChangeStreamCursor<TResult> Watch<TResult>(
            PipelineDefinition<ChangeStreamDocument<BsonDocument>, TResult> pipeline,
            ChangeStreamOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public IChangeStreamCursor<TResult> Watch<TResult>(
            IClientSessionHandle session,
            PipelineDefinition<ChangeStreamDocument<BsonDocument>, TResult> pipeline,
            ChangeStreamOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IChangeStreamCursor<TResult>> WatchAsync<TResult>(
            PipelineDefinition<ChangeStreamDocument<BsonDocument>, TResult> pipeline,
            ChangeStreamOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IChangeStreamCursor<TResult>> WatchAsync<TResult>(
            IClientSessionHandle session,
            PipelineDefinition<ChangeStreamDocument<BsonDocument>, TResult> pipeline,
            ChangeStreamOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public IMongoDatabase WithReadConcern(ReadConcern readConcern)
        {
            throw new System.NotImplementedException();
        }

        public IMongoDatabase WithReadPreference(ReadPreference readPreference)
        {
            throw new System.NotImplementedException();
        }

        public IMongoDatabase WithWriteConcern(WriteConcern writeConcern)
        {
            throw new System.NotImplementedException();
        }
    }
}