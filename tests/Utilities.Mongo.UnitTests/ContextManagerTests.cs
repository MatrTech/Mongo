using FluentAssertions;
using MatrTech.Utilities.Mongo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System;

namespace MatrTech.Utilities.Mongo.UnitTests
{
    [TestClass]
    public class ContextManagerTests
    {
        private const string connectionUrl = "mongodb://localhost:27017";
        private const string databaseName = "foo";

        [TestMethod]
        public void Create_DerivedFromMongoContext_ShouldNotBeNull()
        {
            var context = ContextManager.Create<TestContext>(connectionUrl, databaseName);

            context.Should().NotBeNull();
        }

        [TestMethod]
        public void Create_GetCollectionAfterCreate_ShouldNotBeNull()
        {
            var context = ContextManager.Create<TestContext>(connectionUrl, databaseName);
            string collectionName = $"test-{Guid.NewGuid()}";
            var collection = context.GetCollection<TestDocument>();
            collection.InsertOne(new TestDocument());
            collection.Should().NotBeNull();
        }

        [TestMethod]
        public void Create_CheckIfNonExistingCollectionExists_ShouldBeFalse()
        {
            var context = ContextManager.Create<TestContext>(connectionUrl, $"{Guid.NewGuid()}");
            string collectionName = $"test-{Guid.NewGuid()}";
            context.CollectionExists(collectionName)
                .Should().BeFalse();
        }

        [TestMethod]
        public void Create_CheckParentType_ShouldBeOfTypeMongoContext()
        {
            var context = ContextManager.Create<TestContext>(connectionUrl, databaseName);
            context.Should().BeAssignableTo<MongoContext>();
        }

        [TestMethod]
        public void Foo_TestCase()
        {
            var context = ContextManager.Create<TestContext>(connectionUrl, $"{Guid.NewGuid()}");
            context.TestCollection.InsertOne(new TestDocument());
            Assert.IsTrue(false);
        }

        private class TestDocument : MongoDocumentBase { }

        private class TestContext : MongoContext
        {
            public TestContext(IMongoDatabase database)
                : base(database)
            {
            }

            public MongoCollectionBase<TestDocument> TestCollection { get; set; } = null!;
        }

        private class NotContextDerived { }
    }
}