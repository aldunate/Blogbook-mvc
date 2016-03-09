using System;
using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson.Serialization.Attributes;

namespace Blogbook.Infrastructure.Test.ApiMongoData.Example
{
    [BsonIgnoreExtraElements]
    public class TestEntity : ApiMongoEntity
    {
        public string Description { get; set; }
        public DateTime TimeStamp{ get; set; }
        public List<TestSubEntity> SubEntities{ get; set; }
    }
}