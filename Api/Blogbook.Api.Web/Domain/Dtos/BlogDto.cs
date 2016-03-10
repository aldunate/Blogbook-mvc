using System.Collections.Generic;

namespace Blogbook.Api.Web.Domain.Dtos
{
    public class BlogDto
    {
        public string Id { get; set; }
        public string Name { set; get; }
        public string User { set; get; }
        public string OriginalUrl { set; get; }
        public string ImageBlog { set; get; }
        public string Description { set; get; }
        public List<string> Categories { set; get; }
        public int KViews { set; get; }
        public int KFollowers { set; get; }
        public string Language { set; get; }
    }
}