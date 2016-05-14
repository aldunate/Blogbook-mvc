using System;
using System.Collections.Generic;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Core.Categories
{
    public interface ICategoriesService : IDisposable
    {
        CategoriesEntity GetCategories();
    }
   
}