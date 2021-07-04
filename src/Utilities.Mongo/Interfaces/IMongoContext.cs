using MongoDB.Driver;
using System.Threading.Tasks;

namespace MatrTech.Utilities.Mongo.Interfaces
{
    public interface IMongoContext
    {
        /// <summary>
        /// Checks whether a collection with the name exists within the context.
        /// </summary>
        /// <param name="collectionName">Collection name to check for.</param>
        /// <returns>True if the collection with <paramref name="collectionName"/> exists, otherwise false.</returns>
        bool CollectionExists(string collectionName);

        /// <summary>
        /// Checks whether a collection with the name exists within the context.
        /// </summary>
        /// <param name="collectionName">Collection name to check for.</param>
        /// <returns>True if the collection with <paramref name="collectionName"/> exists, otherwise false.</returns>
        Task<bool> CollectionExistsAsync(string collectionName);

        IMongoCollection<TDocument> GetCollection<TDocument>()
            where TDocument : MongoDocumentBase;
    }
}