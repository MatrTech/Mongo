using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrTech.Utilities.Mongo;
using MatrTech.Utilities.Mongo.Models;
using FluentAssertions;

namespace MatrTech.Utilities.Mongo.UnitTests
{
    [TestClass]
    public class DatabaseManagerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var database = DatabaseManager.Create<TestContext>();

            database.Should().NotBeNull();
        }

        private class TestContext : MongoContext { }
    }
}