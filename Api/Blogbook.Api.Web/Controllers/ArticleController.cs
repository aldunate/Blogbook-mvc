using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Linq;
using Blogbook.Api.Core.Articles;
using Blogbook.Api.Core.Blogs;
using Blogbook.Api.Core.Tokens;
using Blogbook.Api.Core.User;
using Blogbook.Api.Web.Domain.Dtos;
using Blogbook.Api.Web.Domain.Sessions;
using Blogbook.Api.Web.Mappers;
using MongoDB.Bson;


namespace Blogbook.Api.Web.Controllers
{
    public class ArticleController : ApiController
    {        
        private readonly IArticlesService _articleService;
        private readonly ITokensService _tokensService;
        private readonly IBlogsService _blogsService;
        private readonly IUsersService _usersService ;

        public ArticleController()
        {
            _articleService = new ArticlesService();
            _tokensService = new TokensService();
            _blogsService = new BlogsService();
            _usersService = new UsersService();
        }

        // Busca los ultimos 20 articulos 
        public IEnumerable<ArticleEntity> GetLast()
        {           
            return _articleService.GetLast();
        }

        // Busca los articulos por categoría
        public IEnumerable<ArticleEntity> GetByCategory(string category)
        {
            return  _articleService.GetByCategory(category);      
        }
        
        // No se utiliza
        public ArticleDto Get(string id)
        {
            var art = _articleService.GetOneById(id);
            var artDto = DtosMapFactory.Map(art);
            return artDto;
        }


        public IEnumerable<ArticleEntity> GetByBlog(string blogId)
        {
            return _articleService.GetByBlog(blogId);
        }

        public IEnumerable<ArticleEntity> GetFollowArticles(string followToken)
        {

            TokenEntity token = _tokensService.Exist(followToken);
            if (token != null)
            {
                UserEntity user = _usersService.GetUser(BsonObjectId.Create(token.IdUser));
                return _articleService.FindFollows(user.FollowBlogs);
            }
            return null;
        }


        // with query 
        public int GetChange(string id,string modo)
        {
            ArticleEntity art;
            switch (modo)
            {
                case "view":
                    art = _articleService.GetOneById(id);
                    art.KViews++;
                    _articleService.Modify(art);
                    return art.KViews;
                    
                case "like":
                    art = _articleService.GetOneById(id);
                    art.KLikes++;
                    _articleService.Modify(art);
                    return art.KLikes;
                case "share":
                    art = _articleService.GetOneById(id);
                    art.KShared++;
                    _articleService.Modify(art);
                    return art.KShared;
            }
            return -1;
          
        }

        [HttpPost]   // Create article
        public ArticleDto Post(ArticleDto article)
        {
            var queryString = this.Request.GetQueryNameValuePairs();
            var tokenString = queryString.First();
            TokenEntity token = _tokensService.Exist(tokenString.Value);    
            if (token != null)
            {
                var art = DtosMapFactory.Map(article);
                art.BlogId = token.IdBlog;
                _articleService.Insert(art, SessionHelper.GetAudit());
                var artDto = DtosMapFactory.Map(art);
                return artDto;
            }
            return null;
        }
        
        public ArticleDto Delete(string id)
        {
            var artEnt = _articleService.Delete(id);
            var artDto = DtosMapFactory.Map(artEnt);
            return artDto;
        }

        [HttpPut]
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