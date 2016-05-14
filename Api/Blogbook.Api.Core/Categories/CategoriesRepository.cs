using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Blogbook.Api.Core.Categories
{
    public class CategoriesRepository : MongoRepository<CategoriesEntity>, ICategoriesRepository
    {
        public CategoriesRepository(string database, string collectionName) : base(database, collectionName)
        {

        }
     
    }
}