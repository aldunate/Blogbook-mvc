using System;
using System.Collections.Generic;
using System.Linq;
using Blogbook.Api.Core.User;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson;

namespace Blogbook.Api.Core.Tokens
{
    public class TokensService : ITokensService
    {
        private readonly ITokensRepository _repo;

        public TokensService()
        {
            _repo = new TokensRepository("BlogbookMvcApiDb", "Tokens");
        }

        public void Insert(TokenEntity entity)
        {
            _repo.InsertOne(entity);
        }

        public void Delete(string token)
        {            
            _repo.DeleteByToken(token);  // Devulve entity
        }
        public TokenEntity CreateToken(UserEntity user)
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string tokenString = Convert.ToBase64String(time.Concat(key).ToArray());

            TokenEntity token = new TokenEntity
            {
                Token =  tokenString,
                Validado = true,
                IdUser =   user.Id.ToString(),
                IdBlog =  user.IdBlog
            };
            _repo.InsertOne(token);
            return token;
        }

        public TokenEntity Refresh(string token)
        {
            _repo.DeleteByToken(token);  // Devulve entity
            TokenEntity entity = new TokenEntity
            {
                Token = token,
                Validado = true
            };
            _repo.InsertOne(entity);
            return entity;
        }

        public TokenEntity Exist(string token)
        {
            return _repo.FindOne(x => x.Token == token);
        }


        public void Dispose()
        {
            //_repo.Dispose();
        }
    }
}