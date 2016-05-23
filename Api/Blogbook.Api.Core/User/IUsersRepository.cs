using System.Collections.Generic;
using Blogbook.Api.Core.User;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.User
{
    public interface IUsersRepository : IMongoRepository<UserEntity>
    {
     
    }
} 