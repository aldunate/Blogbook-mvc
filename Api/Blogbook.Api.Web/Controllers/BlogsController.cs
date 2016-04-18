using System.Collections.Generic;
using System.Web.Http;
using Blogbook.Api.Core.Blogs;
using Blogbook.Api.Web.Domain.Dtos;
using Blogbook.Api.Web.Domain.Sessions;
using Blogbook.Api.Web.Mappers;
using MongoDB.Bson;


namespace Blogbook.Api.Web.Controllers
{
    public class BlogsController : ApiController
    {
        private readonly IBlogsService _blogsService;

        public BlogsController()
        {
            _blogsService = new BlogsService();
        }

        public IEnumerable<BlogEntity> GetNuevos()
        {
            return _blogsService.GetNuevos();
        }

        public BlogEntity Get(string id)
        {
            //var blogDto = DtosMapFactory.Map(b);
            return _blogsService.GetOne(id);
        }

        //public HttpResponseMessage Post(ArticleDto article)      
        public BlogDto Post(BlogDto blog)
        {
            var b = DtosMapFactory.Map(blog);
            _blogsService.Insert(b, SessionHelper.GetAudit());
            //var response = Request.CreateResponse<ArticleEntity>(System.Net.HttpStatusCode.Created, art);
            var blogDto = DtosMapFactory.Map(b);
            return blogDto;

        }
        public bool Put(BlogDto blog)
        {
            var b = DtosMapFactory.Map(blog);
            var res = _blogsService.Modify(b);
            return res != null;
        }
        
        protected override void Dispose(bool disposing)
        {
            _blogsService.Dispose();
        }

        /*
                public BlogDto Delete(string id)
        {
            var artEnt = _blogsService.Delete(id);
            var artDto = DtosMapFactory.Map(artEnt);
            return artDto;
        }
        */



    }
}
 