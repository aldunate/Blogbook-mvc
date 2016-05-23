using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blogbook.Api.Core.Tokens
{
  
     [BsonIgnoreExtraElements]
    public class TokenEntity : ApiMongoAuditableEntity
    {
        public Boolean Validado { get; set; }
        public string Token { get; set; }    
        public string IdUser { get; set; }

        public string IdBlog { get; set; }

    }

}
