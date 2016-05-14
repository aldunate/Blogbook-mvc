using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Bson.Serialization.Attributes;

namespace Blogbook.Api.Core.Categories
{
    [BsonIgnoreExtraElements]
    public class CategoriesEntity : ApiMongoAuditableEntity 
    {
        public string Language { get; set; }
        public List<CategoryEntity> Categories { set; get; }
    }

    [BsonIgnoreExtraElements]
    public class CategoryEntity : ApiMongoAuditableEntity
    {
        public int IdCategory { set; get; }
        public string  Name { set; get; }
    }
}