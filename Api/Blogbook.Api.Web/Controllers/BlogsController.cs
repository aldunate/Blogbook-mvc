using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using Blogbook.Api.Core.Blogs;
using Blogbook.Api.Core.Tokens;
using Blogbook.Api.Core.User;
using Blogbook.Api.Web.Domain.Dtos;
using Blogbook.Api.Web.Domain.Sessions;
using Blogbook.Api.Web.Mappers;
using MongoDB.Bson;


namespace Blogbook.Api.Web.Controllers
{
    public class BlogsController : ApiController
    {
        private readonly IBlogsService _blogsService;
        private readonly ITokensService _tokensService;
        private readonly IUsersService _usersService;

        public BlogsController()
        {
            _blogsService = new BlogsService();
            _tokensService = new TokensService();
            _usersService = new UsersService();
        }

        public IEnumerable<BlogEntity> GetBlogs()
        {
            return _blogsService.GetBlogs();
        }
        public IEnumerable<BlogEntity> GetBlogs(string follow)
        {
            TokenEntity token = _tokensService.Exist(follow);
            if (token != null)
            {
                UserEntity user = _usersService.GetUser(BsonObjectId.Create(token.IdUser));
                return   _blogsService.FindFollows(user.FollowBlogs);
            }
            return null;
        }


        public BlogEntity Get(string id)
        {
            //var blogDto = DtosMapFactory.Map(b);
            return _blogsService.GetOne(id);
        }
        // Si el usuario esta logueado
        public BlogEntity Get(string id, string token)
        {
            TokenEntity Token = _tokensService.Exist(token);
            if (Token != null)
            {
                UserEntity user = _usersService.GetUser(BsonObjectId.Create(Token.IdUser));
                if (user.FollowBlogs.Contains(ObjectId.Parse(id)))
                {
                    BlogEntity blog =  _blogsService.GetOne(id);
                    blog.AuxFollow = true;
                    return blog;
                }

            }
            return _blogsService.GetOne(id);
        }


        [HttpGet]
        public bool AddFollow(string tokenString, string blog)
        {

            TokenEntity token = _tokensService.Exist(tokenString);
            if (token != null)
            {
                UserEntity user = _usersService.GetUser(BsonObjectId.Create(token.IdUser));
                user.FollowBlogs.Add(ObjectId.Parse(blog));
                var userModify = _usersService.Modify(user);
                return true;
            }
            return false;
        }



        //public HttpResponseMessage Post(ArticleDto article)      
        [HttpPost]
        public bool Update(BlogEntity blog)
        {
            var queryString = this.Request.GetQueryNameValuePairs();
            var tokenString = queryString.First();
            TokenEntity token = _tokensService.Exist(tokenString.Value);
            if (token != null)
            {
                blog.Id = BsonObjectId.Create(blog.IdString);
                var n = _blogsService.Modify(blog);
                return true;
            }
            return false;

        }

        
        protected override void Dispose(bool disposing)
        {
            _blogsService.Dispose();
        }
    }
}
 