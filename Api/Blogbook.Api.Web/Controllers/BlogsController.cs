using System.Collections.Generic;
using System.Web.Http;
using Blogbook.Api.Core.Blogs;
using Blogbook.Api.Web.Domain.Dtos;
using Blogbook.Api.Web.Domain.Sessions;
using Blogbook.Api.Web.Mappers;

namespace Blogbook.Api.Web.Controllers
{
    public class BlogsController : ApiController
    {
        private readonly IBlogsService _blogsService;

        public BlogsController()
        {
            _blogsService = new BlogsService();
        }

        public IEnumerable<BlogDto> Get()
        {
            string variable = "Name";
            string valor = "Los Ojos de Osiris";


            var blogs = _blogsService.GetAllByVariable(variable,valor);
            var blogsDto = DtosMapFactory.Map(blogs);
            return blogsDto;
        }

        public BlogDto Get(string id)
        {
            var b = _blogsService.GetOneByIdAndUser(id, "aldunate");
            var blogDto = DtosMapFactory.Map(b);
            return blogDto;

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

        public BlogDto Delete(string id)
        {
            var artEnt = _blogsService.Delete(id);
            var artDto = DtosMapFactory.Map(artEnt);
            return artDto;
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
    }
}