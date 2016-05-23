using System;
using System.Collections.Generic;
using Blogbook.Api.Core.Articles;
using Blogbook.Api.Core.Blogs;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson;

namespace Blogbook.Api.Core.User
{
    public interface IUsersService : IDisposable
    {
        UserEntity GetUser(UserEntity user);
        UserEntity GetUser(BsonObjectId id);      
        UserEntity Insert(UserEntity entity, AuditTerm auditTerm);
        UserEntity Modify(UserEntity entity);
       
    }
   
}