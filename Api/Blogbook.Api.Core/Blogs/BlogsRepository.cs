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


        private void InicializaQueries()
        {


        }

        // Busca una lista de articulos segun una variable y un valor
        public List<BlogEntity> GetByVariable(string variable,string valor)
        {
            var query = _collection.AsQueryable<BlogEntity>();
            var listArticles = new List<BlogEntity>();
            switch (variable)
            {
                case "Nuevos":
                   
                     query =
                _collection.AsQueryable<BlogEntity>()
                .Select(e => e)
                .OrderBy(e => e.Audit.Created);
                    foreach (var BlogEntity in query)
                    {
                        listArticles.Add(BlogEntity);
                    }
                    return listArticles;
                    // Falta poner un limite de tiempo (semana mes año)
                case "MasVistos":
                   query =
                _collection.AsQueryable<BlogEntity>()
                .OrderBy(e => e.KViews)
                .Select(e => e)
                .Skip(10);
                    foreach (var BlogEntity in query)
                    {
                        listArticles.Add(BlogEntity);
                    }
                    return listArticles;

                    // Hay que recorrer el array y mirar si esta la categoria 
                case "Categories":
                    query =
               _collection.AsQueryable<BlogEntity>()
               .Where(e => e.Categories[0] == valor || e.Categories[1] == valor || e.Categories[2] == valor )
               .Select(e => e);
                    foreach (var BlogEntity in query)
                    {
                        listArticles.Add(BlogEntity);
                    }
                    return listArticles;

            };
            return null;

        }

    }
}