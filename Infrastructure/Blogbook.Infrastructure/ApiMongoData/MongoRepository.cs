using System;
using System.Configuration;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Blogbook.Infrastructure.ApiMongoData
{
    public class MongoRepository<TMongoEntity> : 
        IMongoRepository<TMongoEntity> 
        where TMongoEntity : ApiMongoEntity
    {
        protected readonly IMongoDatabase _db;
        protected readonly IMongoCollection<TMongoEntity> _collection;

        public MongoRepository(
            string database, 
            string collectionName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["mongodb"].ConnectionString;
            var client = new MongoClient(connectionString);
            _db = client.GetDatabase(database);
            _collection = _db.GetCollection<TMongoEntity>(collectionName);
        }

        public IMongoCollection<TMongoEntity> GetCollection()
        {
            return _collection;
        }

        public void DropCollection()
        {
            _db.DropCollection(_collection.CollectionNamespace.CollectionName);
        }

        public TMongoEntity FindOne(Expression<Func<TMongoEntity, bool>> func)
        {
            return _collection.FindSync(func).FirstOrDefault();
        }

        public TMongoEntity FindOne(BsonObjectId id)
        {
            return FindOne(x => x.Id == id);
        }

        public void InsertOne(TMongoEntity entity)
        {
            _collection.InsertOne(entity);
        }

        public long DeleteOne(string id)
        {
            return _collection.DeleteOne(x => x.Id == BsonObjectId.Create(id)).DeletedCount;
        }

        public TMongoEntity Modify(TMongoEntity entity)
        {
            return _collection.FindOneAndReplace(x => x.Id == entity.Id, entity);
        }
    }
}