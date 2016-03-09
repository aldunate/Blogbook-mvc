using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blogbook.Infrastructure.ApiMongoData
{
    public interface IMongoApiRepository<TMongoEntity, TMongoListEntity> : IMongoRepository<TMongoEntity>
        where TMongoEntity : ApiMongoEntity 
        where TMongoListEntity : ApiMongoEntity
    {
        IList<TMongoListEntity> GetList(Expression<Func<TMongoListEntity, bool>> func);
    }
}