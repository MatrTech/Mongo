using MatrTech.Utilities.Extensions.Mongo;
using Matr.Mongo.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matr.Mongo.Models
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
            => database.CollectionExistsAsync(collectionName);

        public IMongoCollection<TDocument> GetCollection<TDocument>()
            where TDocument : MongoDocumentBase
        {
            var documentName = GetCollectionName<TDocument>();
            return database.GetCollection<TDocument>(documentName);
        }

        public IMongoCollection GetCollection(string name)
        {
            throw new NotImplementedException();
        }

        private static string GetCollectionName<TDocument>()
            => typeof(TDocument).ToString().Replace("Document", "");

        private static string GetCollectionName(string propertyName)
            => propertyName.Replace("Collection", string.Empty);

        private void InitializeCollections()
        {
            GetType().GetProperties()
                .Where(propertyInfo => propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(IMongoCollection<>))
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
                        object collectionInstance = CreateCollectionInstance(propertyInfo, genericType);

                        propertyInfo.SetValue(this, collectionInstance);
                    }
                });
            // TODO: We might want to verify if the collection actually exist.
        }

        private object CreateCollectionInstance(System.Reflection.PropertyInfo propertyInfo, Type genericType)
        {
            var method = typeof(IMongoDatabase).GetMethod(nameof(IMongoDatabase.GetCollection))
                ?? throw new NullReferenceException($"Could not find method {nameof(IMongoDatabase.GetCollection)}");

            method = method.MakeGenericMethod(genericType)
                ?? throw new NullReferenceException($"Could not make {nameof(IMongoDatabase.GetCollection)} a generic method");

            var collectionName = GetCollectionName(propertyInfo.Name);
            var collectionInstance = method.Invoke(database, new object?[] { collectionName, null })
                ?? throw new NullReferenceException("Could not resolve collection instance");

            return collectionInstance;
        }
    }
}