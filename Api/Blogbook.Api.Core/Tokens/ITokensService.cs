using System;
using System.Collections.Generic;
using Blogbook.Api.Core.User;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.Tokens
{
    public interface ITokensService : IDisposable
    {
        void Insert(TokenEntity entity);
        void Delete(string token);
        TokenEntity CreateToken(UserEntity user);
        TokenEntity Refresh(string token);
        TokenEntity Exist(string token);
    }
   
}