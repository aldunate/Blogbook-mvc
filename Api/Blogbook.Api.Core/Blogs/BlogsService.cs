using System.Collections.Generic;
using Blogbook.Api.Core.User;
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

        public List<BlogEntity> GetBlogs()
        {  
            return _repo.GetBlogs();
        }


        public List<BlogEntity> FindFollows(List<ObjectId> listId)
        {
            return _repo.FindFollows(listId);
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

        public BlogEntity CreateBlog(string user)
        {
            BlogEntity blog = new BlogEntity
            {
                User = user,
                Name = "Nombre del blog"
            };
            _repo.InsertOne(blog);
            return  _repo.FindOne(x => x.User == user);
        }

        public BlogEntity Delete(string id)
        {
            var r = _repo.DeleteOne(id);
            return null;
        }

        public BlogEntity Modify(BlogEntity entity)
        {
            return _repo.Modify(entity);
        }
        
        public void Dispose()
        {
            //_repo.Dispose();
        }
        
    }
}