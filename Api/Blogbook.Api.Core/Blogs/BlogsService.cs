using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson;

namespace Blogbook.Api.Core.Blogs
{
    public class BlogsService : IBlogsService
    {
        private readonly IBlogsRepository _repo;

        public BlogsService()
        {
            _repo = new BlogsRepository("BlogbookMvcApiDb", "Blogs");
        }

        public List<BlogEntity> GetNuevos()
        {
            
            return _repo.GetNuevos();
        }
        

        public BlogEntity GetOne(string id)
        {
           var s =  new BsonObjectId(ObjectId.Parse(id));
            s = s.AsObjectId;
            return _repo.FindOne(s);
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