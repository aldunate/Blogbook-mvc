using System.Collections.Generic;
using System.Web.Http;
using Blogbook.Api.Core.Articles;
using Blogbook.Api.Web.Domain.Dtos;
using Blogbook.Api.Web.Domain.Sessions;
using Blogbook.Api.Web.Mappers;

namespace Blogbook.Api.Web.Controllers
{
    public class ArticleController : ApiController
    {
        

        private readonly IArticlesService _articleService;

        public ArticleController()
        {
            _articleService = new ArticlesService();
        }

        public IEnumerable<ArticleEntity> GetLast()
        {
            List<ArticleEntity> articles;
            return articles = _articleService.GetLast();
        }
        public IEnumerable<ArticleEntity> GetByCategory(string Category)
        {
            List<ArticleEntity> articles;
            return articles = _articleService.GetByCategory(Category);
            
        }
        

        public ArticleDto Get(string id)
        {
            var art = _articleService.GetOneByIdAndUser(id, "aldunate");
            var artDto = DtosMapFactory.Map(art);
            return artDto;
        }

        //public HttpResponseMessage Post(ArticleDto article)
        public ArticleDto Post(ArticleDto article)
        {
            var art = DtosMapFactory.Map(article);
            _articleService.Insert(art, SessionHelper.GetAudit());
            //var response = Request.CreateResponse<ArticleEntity>(System.Net.HttpStatusCode.Created, art);
            var artDto = DtosMapFactory.Map(art);
            return artDto;
        }

        public ArticleDto Delete(string id)
        {
            var artEnt = _articleService.Delete(id);
            var artDto = DtosMapFactory.Map(artEnt);
            return artDto;
        }

        public bool Put(ArticleDto article)
        {
            var art = DtosMapFactory.Map(article);
            var res = _articleService.Modify(art);
            return res != null;
        }

        protected override void Dispose(bool disposing)
        {
            _articleService.Dispose();
        }
    }
}