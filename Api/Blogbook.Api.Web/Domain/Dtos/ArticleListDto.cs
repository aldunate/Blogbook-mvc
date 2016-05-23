using System.Collections.Generic;

namespace Blogbook.Api.Web.Domain.Dtos
{
    public class ArticleListDto
    {
        public string Id { get; set; }
        public string Title { set; get; }
        public string Content { set; get; }
        public string ContentUrl { set; get; }
        public string ImageUrl { set; get; }
        public List<string> Tags { set; get; }
        public List<string> Categories { set; get; }
        public int KViews { set; get; }
        public int KLikes { set; get; }
        public int KShared { set; get; }
        public string BlogId { set; get; }
        public string Country { set; get; }
        public string BlogName { set; get; }
        public string UserName { get; set; }

    }
}