using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;

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
            return _repo.GetbyCategory(category);
        }
        public List<ArticleEntity> GetLast()
        {
            return _repo.GetLast();         
        }


        public ArticleEntity GetOneByIdAndUser(string id, string userLogin)
        {
            return _repo.FindOne(x => x.Id == id);
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