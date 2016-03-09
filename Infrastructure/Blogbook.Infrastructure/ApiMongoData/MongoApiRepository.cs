using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace Blogbook.Infrastructure.ApiMongoData
{
    public class MongoApiRepository<TMongoEntity, TMongoListEntity> :
        MongoRepository<TMongoEntity>,
        IMongoApiRepository<TMongoEntity, TMongoListEntity>
        where TMongoEntity : ApiMongoEntity
        where TMongoListEntity : ApiMongoEntity
    {
        protected readonly IMongoCollection<TMongoListEntity> _collectionList;

        public MongoApiRepository(
            string database,
            string collectionName) :
                base(database, collectionName)
        {
            _collectionList = _db.GetCollection<TMongoListEntity>(collectionName);
        }

        public IList<TMongoListEntity> GetList(Expression<Func<TMongoListEntity, bool>> func)
        {
            return _collectionList.FindSync<TMongoListEntity>(func).ToList();
        }
    }
}