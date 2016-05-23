using System.Collections.Generic;
using System.Linq;
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

        public List<BlogEntity> FindFollows(List<ObjectId> listId)
        {
            List<BlogEntity> auxList = new List<BlogEntity>();
            List<BlogEntity> blogList = new List<BlogEntity>();
            for (var i = 0; i < listId.Count; i++)
            {
                blogList.AddRange(_collection.Find(x => x.Id == listId[i]).Limit(10).SortBy(x => x.Audit.Created).ToList());
            }
            return blogList; // falta ordenar otra vez los articulos por fecha x => x.Audit.Created OrderBy
        }


        // Busca una lista de articulos segun una variable y un valor
        public List<BlogEntity> GetBlogs()
        {
            return _collection.Find(x => 1 == 1)
            .Limit(20)
            .SortBy(x => x.Audit.Created)
            .ToList();
        }

    }
}