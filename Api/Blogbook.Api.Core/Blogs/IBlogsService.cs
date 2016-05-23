using System;
using System.Collections.Generic;
using Blogbook.Api.Core.User;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson;

namespace Blogbook.Api.Core.Blogs
{
    public interface IBlogsService : IDisposable
    {
        List<BlogEntity> GetBlogs();
        BlogEntity GetOne(string id);
        BlogEntity Insert(BlogEntity entity, AuditTerm auditTerm);
        BlogEntity Delete(string id);
        BlogEntity Modify(BlogEntity entity);
        BlogEntity CreateBlog(string user);
        List<BlogEntity> FindFollows(List<ObjectId> listId);
    }
}