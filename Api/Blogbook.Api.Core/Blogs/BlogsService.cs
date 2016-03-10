using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.Blogs
{
    public class BlogsService : IBlogsService
    {
        private readonly IBlogsRepository _repo;

        public BlogsService()
        {
            _repo = new BlogsRepository("BlogbookMvcApiDb", "Blogs");
        }

        public List<BlogEntity> GetAllByVariable(string variable,string valor)
        {
            return _repo.GetByVariable(variable,valor);
        }
        
        public BlogEntity GetOneByIdAndUser(string id, string userLogin)
        {
            return _repo.FindOne(x => x.Id == id);
        }
        
        public BlogEntity Insert(BlogEntity entity, AuditTerm auditTerm)
        {
            entity.Audit = new Audit
            {
                Created = auditTerm,
                Modified = auditTerm
            };
            _repo.InsertOne(entity);
            return entity;
        }

        public BlogEntity Delete(string id)
        {
            var r = _repo.DeleteOne(id);
            return null;
        }

        public BlogEntity Modify(BlogEntity entity)
        {
            var r = _repo.Modify(entity);
            return r;
        }
        
        public void Dispose()
        {
            //_repo.Dispose();
        }
        
    }
}