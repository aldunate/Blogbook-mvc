using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Linq;

namespace Blogbook.Api.Core.Articles
{
    public class ArticlesRepository : MongoRepository<ArticleEntity>, IArticlesRepository
    {
        public ArticlesRepository(string database, string collectionName) : base(database, collectionName)
        {
        }

        public List<ArticleEntity> GetByBlog(string blogId)
        {
            return _collection.Find(x => x.BlogId == blogId)
                .Limit(20)
                .SortBy(x => x.KLikes)
                .ToList();
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

        public List<ArticleEntity> FindFollows(List<ObjectId> listId)
        {
            List<ArticleEntity> articleList = new List<ArticleEntity>();
            for (var i = 0; i < listId.Count; i++)
            {
                articleList.AddRange(_collection.Find(x => x.BlogId == listId[i].ToString()).Limit(10).SortBy(x => x.Audit.Created).ToList());
            }
            return articleList; // falta ordenar otra vez los articulos por fecha x => x.Audit.Created OrderBy
        }
    }
}