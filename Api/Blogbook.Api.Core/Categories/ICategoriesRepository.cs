using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.Categories
{
    public interface ICategoriesRepository : IMongoRepository<CategoriesEntity>
    {
      
    }
} 