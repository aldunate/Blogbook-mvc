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

        private void InicializaQueries()
        {
        }

        // Busca una lista de articulos segun una variable y un valor
        public List<BlogEntity> GetNuevos()
        {

            return null;
        }

    }
}