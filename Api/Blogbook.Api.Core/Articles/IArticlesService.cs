using System;
using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson;

namespace Blogbook.Api.Core.Articles
{
    public interface IArticlesService : IDisposable
    {

        List<ArticleEntity> GetByCategory(string category);
        List<ArticleEntity> GetLast();
        List<ArticleEntity> GetByBlog(string blogId);
        ArticleEntity GetOneById(string id);
        ArticleEntity Insert(ArticleEntity entity, AuditTerm auditTerm);
        ArticleEntity Delete(string id);
        ArticleEntity Modify(ArticleEntity entity);
        List<ArticleEntity> FindFollows(List<ObjectId> listId);
    }
}