using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.Articles
{
    public interface IArticlesRepository : IMongoRepository<ArticleEntity>
    {
        List<ArticleEntity> GetByVariable(string variable,string valor);
    }
}