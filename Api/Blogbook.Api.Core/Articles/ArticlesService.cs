using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson;

namespace Blogbook.Api.Core.Articles
{
    public class ArticlesService : IArticlesService
    {
        private readonly IArticlesRepository _repo;

        public ArticlesService()
        {
            _repo = new ArticlesRepository("BlogbookMvcApiDb", "Articles");
        }

        public List<ArticleEntity> GetByCategory(string category)
        {
            if(category == "Todas") return _repo.GetLast();
            else return _repo.GetbyCategory(category);
        }

        public List<ArticleEntity> GetByBlog(string blogId)
        {
            return _repo.GetByBlog(blogId);
        }

        public List<ArticleEntity> GetLast()
        {
            return _repo.GetLast();         
        }


        public ArticleEntity GetOneById(string id)
        {
            var s = new BsonObjectId(ObjectId.Parse(id));
            s = s.AsObjectId;
            return _repo.FindOne(s);
        }

        public List<ArticleEntity> FindFollows(List<ObjectId> listId)
        {
            return _repo.FindFollows(listId);
        }

        public ArticleEntity Insert(ArticleEntity entity, AuditTerm auditTerm)
        {
            entity.Audit = new Audit
            {
                Created = auditTerm,
                Modified = auditTerm
            };
            _repo.InsertOne(entity);
            return entity;
        }

        public ArticleEntity Delete(string id)
        {
            var r = _repo.DeleteOne(id);
            return null;
        }

        public ArticleEntity Modify(ArticleEntity entity)
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