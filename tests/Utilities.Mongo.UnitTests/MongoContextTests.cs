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

        private class TestMongoContext : MongoContext
        {
            public TestMongoContext(IMongoDatabase database)
                : base(database)
            {
            }
        }
    }
}