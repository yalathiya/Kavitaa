using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Kavita.Connection
{
    public static class Services
    {
        public static BsonDocument ConvertModelToBson(dynamic objModel)
        {
            BsonDocument bsonDocument = BsonSerializer.Deserialize<BsonDocument>(objModel.ToJson());
            return bsonDocument;
        }
    }
}