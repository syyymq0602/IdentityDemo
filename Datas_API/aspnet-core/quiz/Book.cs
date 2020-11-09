using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quiz
{
    public class Book 
    {
        [BsonId]
        [BsonRepresentation(BsonType.Timestamp)]
        public BsonTimestamp time { get; set; }
        public double data { get; set; }

    }
}
