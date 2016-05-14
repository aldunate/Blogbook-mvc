using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Blogbook.Api.Core.Articles
{
    public class ArticlesRepository : MongoRepository<ArticleEntity>, IArticlesRepository
    {
        public ArticlesRepository(string database, string collectionName) : base(database, collectionName)
        {
        }


        public List<ArticleEntity> GetbyCategory(string category)
        {
            return _collection.Find(x => x.Categories[0] == category || x.Categories[1] == category || x.Categories[2] == category)
                .Limit(20)
                .SortBy(x=>x.KLikes)
                .ToList();
        }
        public List<ArticleEntity> GetLast()
        {
            return _collection.Find(x => 1 == 1)
                .Limit(20)
                .SortBy(x => x.Audit.Created)
                .ToList();
        }

        
    }
}