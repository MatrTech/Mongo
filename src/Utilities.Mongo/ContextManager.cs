using MatrTech.Utilities.Helpers;
using MatrTech.Utilities.Mongo.Models;
using MongoDB.Driver;
using System;

namespace MatrTech.Utilities.Mongo
{
    /// <summary>
    /// Manager of everything involving MongoContexts
    /// </summary>
    public class ContextManager
    {
        /// <summary>
        /// Creates a Context from the <paramref name="connectionUrl"/> and the <paramref name="databaseName"/>.
        /// </summary>
        /// <typeparam name="TContext">The Context type to create.</typeparam>
        /// <param name="connectionUrl">The ConnectionUrl to connect the Context to.</param>
        /// <param name="databaseName">The name of the database to connect to.</param>
        /// <returns>The Context of Type <typeparamref name="TContext"/>.</returns>
        public static TContext Create<TContext>(string connectionUrl, string databaseName)
            where TContext : MongoContext
        {
            var client = new MongoClient(connectionUrl);
            IMongoDatabase database = client.GetDatabase(databaseName) ?? throw new NullReferenceException();

            var result = ActivatorHelper.CreateInstance<TContext>(database) ?? throw new NullReferenceException();
            return result;
        }
    }
}