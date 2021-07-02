using FluentAssertions;
using MatrTech.Utilities.Mongo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MatrTech.Utilities.Mongo.UnitTests
{
    [TestClass]
    public class DatabaseManagerTests
    {
        private const string connectionUrl = "mongodb://localhost:27017";
        private const string databaseName = "foo";

        [TestMethod]
        public void Create_DerivedFromMongoContext_ShouldNotBeNull()
        {
            var database = DatabaseManager.Create<TestContext>(connectionUrl, databaseName);

            database.Should().NotBeNull();
        }

        [TestMethod]
        public void Create_GetCollectionAfterCreate_ShouldNotBeNull()
        {
            var database = DatabaseManager.Create<TestContext>(connectionUrl, databaseName);
            string collectionName = $"test-{Guid.NewGuid()}";
            var collection = database.GetCollection<BsonDocument>(collectionName);
            collection.InsertOne(new TestDocument().ToBsonDocument());
            collection.Should().NotBeNull();
        }

        [TestMethod]
        public void Create_CheckIfNonExistingCollectionExists_ShouldBeFalse()
        {
            var database = DatabaseManager.Create<TestContext>(connectionUrl, databaseName);
            string collectionName = $"test-{Guid.NewGuid()}";
            var collection = database.GetCollection<BsonDocument>(collectionName).Exists().Should();
            collection.Should().NotBeNull();
        }

        [TestMethod]
        public void Create_CheckParentType_ShouldBeOfTypeMongoContext()
        {
            var database = DatabaseManager.Create<TestContext>(connectionUrl, databaseName);
            database.Should().BeAssignableTo<MongoContext>();
        }

        private class TestDocument { }

        private class TestContext : MongoContext
        {
            public TestContext(IMongoDatabase database)
                : base(database)
            {
            }

            public IMongoCollection<TestDocument> TestCollection { get; set; }
        }

        private class NotContextDerived { }
    }
}