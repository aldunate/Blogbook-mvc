using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.Http;
using Blogbook.Api.Core.Articles;
using Blogbook.Api.Core.Tokens;
using Blogbook.Api.Core.User;
using Blogbook.Api.Web.Domain.Dtos;
using Blogbook.Api.Web.Domain.Sessions;
using Blogbook.Api.Web.Mappers;
using MongoDB.Bson;
using MongoDB.Driver.Core.Authentication;

namespace Blogbook.Api.Web.Controllers
{
    //[Route("auth")]
    public class AuthController : ApiController
    {
        protected UsersService UserService;
        protected TokensService TokensService;
        //private readonly IAuthenticator _auth;
        public AuthController()
        {
            UserService = new UsersService();
            TokensService = new TokensService();
        }

        

       
  
    }
}
