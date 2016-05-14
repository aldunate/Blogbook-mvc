using System.Collections.Generic;
using System.Web.Http;
using Blogbook.Api.Core.Categories;
using Blogbook.Api.Web.Domain.Dtos;
using Blogbook.Api.Web.Domain.Sessions;
using Blogbook.Api.Web.Mappers;
using MongoDB.Bson;

namespace Blogbook.Api.Web.Controllers
{
    public class CategoriesController : ApiController

    {
        private readonly ICategoriesService _categoryService;

        public CategoriesController()
        {
            _categoryService = new CategoriesService();
        }


        public CategoriesEntity GetCategories()
        {
            return _categoryService.GetCategories();
        }


        protected override void Dispose(bool disposing)
        {
            _categoryService.Dispose();
        }


    }
}