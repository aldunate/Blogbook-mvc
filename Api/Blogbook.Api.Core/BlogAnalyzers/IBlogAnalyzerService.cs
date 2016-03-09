using System;
using Blogbook.Api.Core.BlogAnalyzers.Entities;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.BlogAnalyzers
{
    public interface IBlogAnalyzerService : IDisposable
    {
        BlogAnalyzerEntity GetOneByIdAndUser(string id, string userLogin);
        BlogAnalyzerEntity Insert(BlogAnalyzerEntity entity, AuditTerm auditTerm);
        BlogAnalyzerEntity Delete(string id);
        BlogAnalyzerEntity Modify(BlogAnalyzerEntity entity);
    }
}