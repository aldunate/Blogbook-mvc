using System.Collections.Generic;
using Blogbook.Api.Core.Tokens;
using Blogbook.Api.Core.User;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.Tokens
{
    public interface ITokensRepository : IMongoRepository<TokenEntity>
    {
        TokenEntity DeleteByToken(string token);
    }
} 