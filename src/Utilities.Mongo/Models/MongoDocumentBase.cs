using System;
using MongoDB.Bson;

namespace MatrTech.Utilities.Mongo
{
    public abstract class MongoDocumentBase
    {
        public ObjectId Id { get; set; }
    }
}