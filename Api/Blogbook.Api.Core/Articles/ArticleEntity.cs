using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson.Serialization.Attributes;

namespace Blogbook.Api.Core.Articles
{
    [BsonIgnoreExtraElements]
    public class ArticleEntity : ApiMongoAuditableEntity 
    {
        public string Title { set; get; }
        public string Content { set; get; }
        public string ContentUrl { set; get; }
        public string ImageUrl { set; get; }
        public List<string> Tags { set; get; }
        public List<string> Categories { set; get; }
        public int KViews { set; get; }
        public int KLikes { set; get; }
        public int KShared { set; get; }
        public string BlogId { set; get; }
        public string Country { set; get; }
        public string Language { set; get; }
        public string UserLogin { set; get; }
    }
}