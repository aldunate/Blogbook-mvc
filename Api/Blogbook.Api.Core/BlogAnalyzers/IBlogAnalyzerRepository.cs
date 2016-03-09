using Blogbook.Api.Core.BlogAnalyzers.Entities;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.BlogAnalyzers
{
    public interface IBlogAnalyzerRepository : IMongoRepository<BlogAnalyzerEntity>
    {
    }
}