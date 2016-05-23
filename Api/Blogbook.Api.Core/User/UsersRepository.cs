using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
namespace Blogbook.Api.Core.User
{
    public class UsersRepository : MongoRepository<UserEntity>, IUsersRepository
    {
        public UsersRepository(string database, string collectionName) : base(database, collectionName)
        {

        }
        private void InicializaQueries()
        {
        }

     

        
    }
}