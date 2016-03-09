using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson.Serialization.Attributes;

namespace Blogbook.Api.Core.Blogs
{
    [BsonIgnoreExtraElements]
    public class BlogEntity : ApiMongoAuditableEntity
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string BlogUrl { get; set; }
        public string ImageBlog { get; set; }
        public int kViews { get; set; }
        public int kFollowers { get; set; }
        public string Description { get; set; }
        public List<string> Categories { get; set; }
    }
}