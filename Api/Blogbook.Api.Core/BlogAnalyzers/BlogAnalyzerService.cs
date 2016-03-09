using Blogbook.Api.Core.BlogAnalyzers.Entities;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.BlogAnalyzers
{
    public class BlogAnalyzerService : IBlogAnalyzerService
    {
        private readonly IBlogAnalyzerRepository _repo;

        public BlogAnalyzerService()
        {
            _repo = new BlogAnalyzerRepository("BlogbookMvcApiDb", "Articles");
        }

        public BlogAnalyzerEntity GetOneByIdAndUser(string id, string userLogin)
        {
            return _repo.FindOne(x => x.Id == id);
        }

        public BlogAnalyzerEntity Insert(BlogAnalyzerEntity entity, AuditTerm auditTerm)
        {
            entity.Audit = new Audit
            {
                Created = auditTerm,
                Modified = auditTerm
            };
            _repo.InsertOne(entity);
            return entity;
        }

        public BlogAnalyzerEntity Delete(string id)
        {
            var r = _repo.DeleteOne(id);
            return null;
        }

        public BlogAnalyzerEntity Modify(BlogAnalyzerEntity entity)
        {
            var r = _repo.Modify(entity);
            return r;
        }

        public void Dispose()
        {
            //_repo.DDispose();
        }
    }
}