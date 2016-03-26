using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.Articles
{
    public interface IArticlesRepository : IMongoRepository<ArticleEntity>
    {

        List<ArticleEntity> GetbyCategory(string category);
        List<ArticleEntity> GetLast();
    }
}