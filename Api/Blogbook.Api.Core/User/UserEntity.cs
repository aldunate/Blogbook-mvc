using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blogbook.Api.Core.User
{
    [BsonIgnoreExtraElements]
    public class UserEntity : ApiMongoAuditableEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string IdBlog { get; set; }

        public List<ObjectId> FollowBlogs { get; set; } 
       
    }

}