using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Blogbook.Api.Core.Blogs
{
    [BsonIgnoreExtraElements]
    public class BlogEntity : ApiMongoAuditableEntity 
    {
        public string IdString { set; get; }
        public string Name { set; get; }
        public string User { set; get; }
        public string OriginalUrl { set; get; }
        public string ImageBlog { set; get; }
        public string Description { set; get; }
        public List<string> Categories { set; get; }
        public int KViews { set; get; }
        public int KFollowers { set; get; }
        public string Language { set; get; }

    }
}