using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Blogbook.Api.Core.Articles
{
    public class ArticlesRepository : MongoRepository<ArticleEntity>, IArticlesRepository
    {
        public ArticlesRepository(string database, string collectionName) : base(database, collectionName)
        {
        }

        // Busca un articulo por ID
        public ArticleEntity GetById(string id)
        {
            var obId = ObjectId.Parse(id);
            ArticleEntity article = new ArticleEntity();
            var query = _collection.AsQueryable<ArticleEntity>()
                .Where(e => e.Id == obId )
                .Select(e => e);
            return article;
        }

        // Busca una lista de articulos segun una variable y un valor
        public List<ArticleEntity> GetByVariable(string variable,string valor)
        {
            var query = _collection.AsQueryable<ArticleEntity>();
            var listArticles = new List<ArticleEntity>();
            switch (variable)
            {
                case "UserLogin":
                   
                     query =
                _collection.AsQueryable<ArticleEntity>()
                .Where(e => e.UserLogin == valor)
                .Select(e => e);
                    foreach (var ArticleEntity in query)
                    {
                        listArticles.Add(ArticleEntity);
                    }


                    return listArticles;

                case "5":
                   query =
                _collection.AsQueryable<ArticleEntity>()
                .Where(e => e.UserLogin == valor)
                .Select(e => e);
                    foreach (var ArticleEntity in query)
                    {
                        listArticles.Add(ArticleEntity);
                    }
                    return listArticles;

                default:
                    return null;

            };
            

        }

    }
}