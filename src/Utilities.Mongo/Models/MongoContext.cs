using MatrTech.Utilities.Extensions.Mongo;
using MatrTech.Utilities.Mongo.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MatrTech.Utilities.Mongo.Models
{
    public abstract class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase database;
        private readonly IList<Type> collections = new List<Type>();

        public MongoContext(IMongoDatabase database)
        {
            this.database = database;

            InitializeCollections();
        }

        public bool CollectionExists(string collectionName)
            => database.CollectionExists(collectionName);

        public Task<bool> CollectionExistsAsync(string collectionName)
        {
            throw new System.NotImplementedException();
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>()
            where TDocument : MongoDocumentBase
        {
            var documentName = GetCollectionName<TDocument>();
            return database.GetCollection<TDocument>(documentName);
        }

        private string GetCollectionName<TDocument>()
            => typeof(TDocument).ToString().Replace("Document", "");


        private void InitializeCollections()
        {
            this.GetType().GetProperties()
                .Where(propertyInfo => propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(MongoCollectionBase<>))
                .ToList()
                .ForEach(propertyInfo =>
                {
                    var genericType = propertyInfo.PropertyType.GetGenericArguments().FirstOrDefault();
#if NETCOREAPP3_1
                    if (!(genericType is null) && !collections.Contains(genericType))
#else
                    if (genericType is not null && !collections.Contains(genericType))
#endif
                    {
                        collections.Add(genericType);
                        var method = typeof(IMongoDatabase).GetMethod(nameof(IMongoDatabase.GetCollection)) ?? throw new Exception();
                        method = method.MakeGenericMethod(genericType) ?? throw new Exception();

                        // TODO: verify name or get it from configuration
                        var collectionName = propertyInfo.Name.Replace("Collection", string.Empty);
                        var collectionInstance = method.Invoke(database, new object?[] { collectionName, null });

                        propertyInfo.SetValue(this, collectionInstance);
                    }
                });
            // TODO: We might want to verify if the collection actually exist.
        }
    }
}