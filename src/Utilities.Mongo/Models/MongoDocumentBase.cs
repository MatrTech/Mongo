using System;
using MongoDB.Bson;

namespace Matr.Mongo
{
    public abstract class MongoDocumentBase
    {
        public ObjectId Id { get; set; }
    }
}