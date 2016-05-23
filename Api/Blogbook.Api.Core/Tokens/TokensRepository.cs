using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using Blogbook.Api.Core.Tokens;

namespace Blogbook.Api.Core.Tokens
{
    public class TokensRepository : MongoRepository<TokenEntity>, ITokensRepository
    {
        public TokensRepository(string database, string collectionName) : base(database, collectionName)
        {

        }
        private void InicializaQueries()
        {
        }
        public TokenEntity DeleteByToken(string token)
        {
            return _collection.FindOneAndDelete(x => x.Token == token); 
        }



    }
}