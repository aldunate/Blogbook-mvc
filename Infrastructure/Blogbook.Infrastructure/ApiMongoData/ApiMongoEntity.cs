using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blogbook.Infrastructure.ApiMongoData
{
    public abstract class ApiMongoEntity
    {
        protected ApiMongoEntity()
        {
            Id = new BsonObjectId(ObjectId.GenerateNewId());
        }

        [BsonId]
        public BsonObjectId Id { get; set; }
    }    
}

