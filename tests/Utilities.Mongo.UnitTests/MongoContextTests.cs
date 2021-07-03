using FluentAssertions;
using MatrTech.Utilities.Mongo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System;

namespace MatrTech.Utilities.Mongo.UnitTests
{
    [TestClass]
    public class MongoContextTests
    {
        private const string connectionUrl = "mongodb://localhost:27017";

        [TestMethod]
        public void Client_ContextValid_ShouldNotBeNull()
        {
            string databaseName = $"{Guid.NewGuid()}";
            var context = DatabaseManager.Create<TestMongoContext>(connectionUrl, databaseName);
            context.Client.Should().NotBeNull();
        }

        [TestMethod]
        public void Client_ContextNull_ShouldThrowNullReferenceException()
        {
            TestMongoContext context = null!;
            Func<IMongoClient> func = () => context.Client;
            func.Should().Throw<NullReferenceException>();
        }

        [TestMethod]
        public void DatabaseNamespace_ValidContext_ShouldNotBeNull()
        {
            string databaseName = $"{Guid.NewGuid()}";
            var context = DatabaseManager.Create<TestMongoContext>(connectionUrl, databaseName);
            context.DatabaseNamespace.Should().NotBeNull();
        }

        private class TestMongoContext : MongoContext
        {
            public TestMongoContext(IMongoDatabase database)
                : base(database)
            {
            }
        }
    }
}