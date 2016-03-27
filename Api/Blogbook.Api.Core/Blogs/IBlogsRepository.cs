using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.Blogs
{
    public interface IBlogsRepository : IMongoRepository<BlogEntity>
    {
        List<BlogEntity> GetNuevos();
    }
}