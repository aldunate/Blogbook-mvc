using System;
using System.Collections.Generic;
using System.Linq;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson;

namespace Blogbook.Api.Core.User
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repo;

        public UsersService()
        {
            _repo = new UsersRepository("BlogbookMvcApiDb", "Users");
        }



        public UserEntity GetUser(UserEntity user)
        {
            return _repo.FindOne(x => x.Name == user.Name && x.Password == user.Password);
        }
        public UserEntity GetUser(BsonObjectId id)
        {
            return _repo.FindOne(x => x.Id == BsonObjectId.Create(id));
        }

        public UserEntity Insert(UserEntity entity, AuditTerm auditTerm)
        {
            entity.Audit = new Audit
            {
                Created = auditTerm,
                Modified = auditTerm
            };
            entity.FollowBlogs =  new List<ObjectId>();
            _repo.InsertOne(entity);
            return entity;
        }

        public UserEntity Modify(UserEntity entity)
        {
            return _repo.Modify(entity);           
        }

        public void Dispose()
        {
            //_repo.Dispose();
        }
    }
}