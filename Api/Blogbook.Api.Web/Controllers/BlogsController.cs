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

        public IEnumerable<BlogEntity> Get()
        {
            if (this.Request.RequestUri.Query != "")
            {
                char delimite = '=';
                string text = this.Request.RequestUri.Query;
                text = text.TrimStart('?');
                string[] q = text.Split(delimite);
                // En los espacios colo '+' -- HAY QUE MODIFICARLO
                string variable = q[0];
                string valor = q[1];

                var blogs = _blogsService.GetAllByVariable(variable, valor);
                //var blogsDto = DtosMapFactory.Map(blogs);
                return blogs;
            }
            return null;
        }

        public BlogEntity Get(string id)
        {
            var blog = _blogsService.GetOne(id);
            //var blogDto = DtosMapFactory.Map(b);
            return blog;

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