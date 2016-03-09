using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson.Serialization.Attributes;

namespace Blogbook.Api.Core.BlogAnalyzers.Entities
{
    [BsonIgnoreExtraElements]
    public class BlogAnalyzerEntity : ApiMongoAuditableEntity 
    {
        public BlogAnalyzerEntity()
        {
            EnumState = Entities.EnumState.ImagesUrlPending;
        }

        public string EnumState { set; get; }
        public string BlogUrl { set; get; }
        public List<ImageUrl> ImagesUrls { set; get; }
    }
}