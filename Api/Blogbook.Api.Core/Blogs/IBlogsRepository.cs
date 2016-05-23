using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson;

namespace Blogbook.Api.Core.Blogs
{
    public interface IBlogsRepository : IMongoRepository<BlogEntity>
    {
        List<BlogEntity> GetBlogs();
        List<BlogEntity> FindFollows(List<ObjectId> listId);
    }
}