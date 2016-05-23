
using System.Collections.Generic;
using System.Web.Http;
using Blogbook.Api.Core.Blogs;
using Blogbook.Api.Core.User;
using Blogbook.Api.Core.Tokens;
using Blogbook.Api.Web.Domain.Dtos;
using Blogbook.Api.Web.Domain.Sessions;
using Blogbook.Api.Web.Mappers;
using MongoDB.Bson;

namespace Blogbook.Api.Web.Controllers
{

    public class UserController : ApiController
    {

        protected UsersService UserService;
        protected TokensService TokensService;
        protected BlogsService BlogsService;

        public UserController()
        {
            UserService = new UsersService();
            TokensService = new TokensService();
            BlogsService = new BlogsService(); 
        }

        [HttpPost]
        public TokenEntity SignUp(UserEntity user)
        {
            // Buscar si ya existe el usuario
            if (UserService.GetUser(user) == null)
            {
                BlogEntity blog = BlogsService.CreateBlog(user.Name);
                user.IdBlog = blog.Id.ToString();
                user = UserService.Insert(user, SessionHelper.GetAudit());
                TokenEntity token = TokensService.CreateToken(user);
                token.IdBlog = blog.Id.ToString();
                return token;
            }
            return null;           
        }


        [HttpGet]
        public TokenEntity SignIn(string name, string password)
        {
            UserEntity user = new UserEntity 
            {
                Name = name,
                Password = password
            };
            user = UserService.GetUser(user);
            if (user != null)
            {
                return TokensService.CreateToken(user) ;
            }
            return null;    
        }

        [HttpGet] // FALTA POR DESARROLLAR
        public TokenEntity actualizaToken(string token,string modo)
        {
            if (modo == "borrar")
            {            
                TokensService.Delete(token);
                return null;
            }
            return TokensService.Refresh(token);
        }


    }
}
