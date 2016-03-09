using System;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Blogbook.Infrastructure.ApiMongoData
{
    public interface IMongoRepository<TMongoEntity> 
        where TMongoEntity : ApiMongoEntity
    {
        IMongoCollection<TMongoEntity> GetCollection();
        void DropCollection();
        TMongoEntity FindOne(Expression<Func<TMongoEntity, bool>> func);
        TMongoEntity FindOne(BsonObjectId id);
        void InsertOne(TMongoEntity entity);
        long DeleteOne(string id);
        TMongoEntity Modify(TMongoEntity entity);
    }
}