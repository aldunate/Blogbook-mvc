using System.Collections.Generic;
using System.Linq;
using Blogbook.Api.Core.Articles;
using Blogbook.Api.Core.Blogs;
using Blogbook.Api.Web.Domain.Dtos;
using MongoDB.Bson;

namespace Blogbook.Api.Web.Mappers
{
    public static class DtosMapFactory
    {
        public static List<ArticleDto> Map(List<ArticleEntity> entities)
        {
            var r = new List<ArticleDto>();
            if (entities == null || !entities.Any()) return r;

            entities.ForEach(x => r.Add(Map(x)));
            return r;
        }

        public static ArticleDto Map(ArticleEntity entity)
        {
            var r = new ArticleDto
            {
                Id = entity.Id.ToString(),
                Title = entity.Title,
                BlogId = entity.BlogId,
                Country = entity.Country,               
                Content = entity.Content,
                ContentUrl = entity.ContentUrl,
                ImageUrl = entity.ImageUrl,
            };

            r.Categories = new List<string>();
            if (entity.Categories != null && entity.Categories.Any())
                r.Categories.AddRange(entity.Categories);

            r.Tags = new List<string>();
            if (entity.Tags!=null && entity.Tags.Any())
                r.Tags.AddRange(entity.Tags);

            return r;
        }
        
        public static ArticleEntity Map(ArticleDto dto)
        {
            var r = new ArticleEntity
            {
                Title = dto.Title,
                Content = dto.Content,
                ImageUrl = dto.ImageUrl,
                ContentUrl = dto.ContentUrl,
                Country = dto.Country
            };

            if (dto.Id != null)
                r.Id = BsonObjectId.Create(dto.Id);

            r.Categories = new List<string>();
            if (dto.Categories != null && dto.Categories.Any())
                r.Categories.AddRange(dto.Categories);

            r.Tags = new List<string>();
            if (dto.Tags != null && dto.Tags.Any())
                r.Tags.AddRange(dto.Tags);

            return r;
        }


        public static List<BlogDto> Map(List<BlogEntity> entities)
        {
            var r = new List<BlogDto>();
            if (entities == null || !entities.Any()) return r;

            entities.ForEach(x => r.Add(Map(x)));
            return r;
        }

        public static BlogDto Map(BlogEntity entity)
        {
            var r = new BlogDto
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                User = entity.User,
                OriginalUrl = entity.OriginalUrl,
                ImageBlog = entity.ImageBlog,
                Description = entity.Description,
                Language = entity.Language
             };


            r.Categories = new List<string>();
            if (entity.Categories != null && entity.Categories.Any())
                r.Categories.AddRange(entity.Categories);

            return r;
        }

        public static BlogEntity Map(BlogDto dto)
        {
            var r = new BlogEntity
            {
                Name = dto.Name,
                User = dto.User,
                OriginalUrl = dto.OriginalUrl,
                ImageBlog = dto.ImageBlog,
                Description = dto.Description,
                Language = dto.Language
            };

            if (dto.Id != null)
                r.Id = BsonObjectId.Create(dto.Id);
            r.Categories = new List<string>();
            if (dto.Categories != null && dto.Categories.Any())
                r.Categories.AddRange(dto.Categories);
            return r;
        }


    }
}