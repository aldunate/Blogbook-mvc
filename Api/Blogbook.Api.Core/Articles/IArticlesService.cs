using System;
using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.Articles
{
    public interface IArticlesService : IDisposable
    {

        List<ArticleEntity> GetByCategory(string category);
        List<ArticleEntity> GetLast();
        ArticleEntity GetOneByIdAndUser(string id, string userLogin);
        ArticleEntity Insert(ArticleEntity entity, AuditTerm auditTerm);
        ArticleEntity Delete(string id);
        ArticleEntity Modify(ArticleEntity entity);
    }
}