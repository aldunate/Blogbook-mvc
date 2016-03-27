using System;
using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.Blogs
{
    public interface IBlogsService : IDisposable
    {
        List<BlogEntity> GetNuevos();
        BlogEntity GetOne(string id);
        BlogEntity GetOneByIdAndUser(string id, string userLogin);
        BlogEntity Insert(BlogEntity entity, AuditTerm auditTerm);
        BlogEntity Delete(string id);
        BlogEntity Modify(BlogEntity entity);

    }
}