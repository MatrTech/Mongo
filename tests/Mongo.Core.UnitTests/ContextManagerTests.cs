using FluentAssertions;
using Matr.Mongo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace Matr.Mongo.UnitTests
{
    [TestClass]
    public class ContextManagerTests
    {
        private const string connectionUrl = "mongodb://localhost:27017";

        [TestMethod]
        public void Create_DerivedFromMongoContext_ShouldNotBeNull()
        {
            var databaseName = $"{Guid.NewGuid()}";
            ContextManager.Create<TestContext>(connectionUrl, databaseName)
                .Should()
                .NotBeNull();
        }

        [TestMethod]
        public void Create_GetCollectionAfterCreate_ShouldNotBeNull()
        {
            var databaseName = $"{Guid.NewGuid()}";
            var context = ContextManager.Create<TestContext>(connectionUrl, databaseName);

            context.GetCollection<TestDocument>()
                .Should()
                .NotBeNull();
        }

        [TestMethod]
        public void Create_CheckIfNonExistingCollectionExists_ShouldBeFalse()
        {
            var context = ContextManager.Create<TestContext>(connectionUrl, $"{Guid.NewGuid()}");
            string collectionName = $"test-{Guid.NewGuid()}";
            context.CollectionExists(collectionName)
                .Should()
                .BeFalse();
        }

        [TestMethod]
        public void Create_CheckParentType_ShouldBeOfTypeMongoContext()
        {
            var databaseName = $"{Guid.NewGuid()}";

            ContextManager.Create<TestContext>(connectionUrl, databaseName)
                .Should()
                .BeAssignableTo<MongoContext>();
        }

        [TestMethod]
        public void ContextCollection_ValidCollection_ElementInserted()
        {
            var databaseName = $"{Guid.NewGuid()}";
            var context = ContextManager.Create<TestContext>(connectionUrl, databaseName);
            var collection = context.TestCollection;
            collection.InsertOne(new TestDocument());
            collection.Find(new BsonDocument())
                .CountDocuments()
                .Should()
                .Be(1);
        }

        [TestMethod]
        public void CollectionExists_ContextCollection_ShouldBeTrue()
        {
            var databaseName = $"{Guid.NewGuid()}";
            var context = ContextManager.Create<TestContext>(connectionUrl, databaseName);
            context.TestCollection.InsertOne(new TestDocument());
            context.CollectionExists("Test")
                .Should()
                .BeTrue();
        }

        [TestMethod]
        public void CollectionExists_CollectionDoesNotExist_ShouldBeFalse()
        {
            var databaseName = $"{Guid.NewGuid()}";
            var collectionName = $"{Guid.NewGuid()}";
            var context = ContextManager.Create<TestContext>(connectionUrl, databaseName);
            context.CollectionExists(collectionName)
                .Should()
                .BeFalse();
        }

        private class TestDocument : MongoDocumentBase { }

        private class OtherTestDocument : MongoDocumentBase { }

        private class TestContext : MongoContext
        {
            public TestContext(IMongoDatabase database)
                : base(database)
            {
            }

            public IMongoCollection<TestDocument> TestCollection { get; set; } = null!;
            public IMongoCollection<OtherTestDocument> OtherTestCollection { get; set; } = null!;
        }

        private class UnattachedCollection { }

        private class NotContextDerived { }
    }
}