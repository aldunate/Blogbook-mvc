using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _repo;

        public CategoriesService()
        {
            _repo = new CategoriesRepository("BlogbookMvcApiDb", "Categories");
        }

        public CategoriesEntity GetCategories()
        {
            return _repo.FindOne(x => x.Language == "es");

        }


        public void Dispose()
        {
            //_repo.Dispose();
        }
    }
}