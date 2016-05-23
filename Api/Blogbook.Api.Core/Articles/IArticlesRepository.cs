using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson;

namespace Blogbook.Api.Core.Articles
{
    public interface IArticlesRepository : IMongoRepository<ArticleEntity>
    {

        List<ArticleEntity> GetbyCategory(string category);
        List<ArticleEntity> GetLast();
        List<ArticleEntity> GetByBlog(string blogId);
        List<ArticleEntity> FindFollows(List<ObjectId> listId);
    }
}