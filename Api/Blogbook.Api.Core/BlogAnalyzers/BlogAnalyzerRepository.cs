using Blogbook.Api.Core.BlogAnalyzers.Entities;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.BlogAnalyzers
{
    public class BlogAnalyzerRepository : MongoRepository<BlogAnalyzerEntity>, IBlogAnalyzerRepository
    {
        public BlogAnalyzerRepository(string database, string collectionName) : base(database, collectionName)
        {
        }
    }
}