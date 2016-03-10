using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Blogbook.Api.Core.Blogs
{
    public class BlogsRepository : MongoRepository<BlogEntity>, IBlogsRepository
    {
        public BlogsRepository(string database, string collectionName) : base(database, collectionName)
        {
        }

        // Busca un articulo por ID
        public BlogEntity GetById(string id)
        {
            var obId = ObjectId.Parse(id);
            BlogEntity article = new BlogEntity();
            var query = _collection.AsQueryable<BlogEntity>()
                .Where(e => e.Id == obId )
                .Select(e => e);
            return article;
        }

        // Busca una lista de articulos segun una variable y un valor

        public List<BlogEntity> GetByVariable(string variable,string valor)
        {
            var query = _collection.AsQueryable<BlogEntity>();
            var listArticles = new List<BlogEntity>();
            switch (variable)
            {
                case "Name":
                   
                     query =
                _collection.AsQueryable<BlogEntity>()
                .Where(e => e.Name == valor)
                .Select(e => e);
                    foreach (var BlogEntity in query)
                    {
                        listArticles.Add(BlogEntity);
                    }


                    return listArticles;

                case "5":
                   query =
                _collection.AsQueryable<BlogEntity>()
                .Where(e => e.Name == valor)
                .Select(e => e);
                    foreach (var BlogEntity in query)
                    {
                        listArticles.Add(BlogEntity);
                    }
                    return listArticles;

                default:
                    return null;

            };
            

        }

    }
}