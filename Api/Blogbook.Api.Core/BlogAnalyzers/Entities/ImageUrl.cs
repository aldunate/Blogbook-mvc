namespace Blogbook.Api.Core.BlogAnalyzers.Entities
{
    public class ImageUrl
    {
        public ImageUrl()
        {
            EnumImageStatus = Entities.EnumImageStatus.Pending;
        }

        public string Id { set; get; }
        public string Url { set; get; }
        public string EnumImageStatus { set; get; }
        public int Length { set; get; }
        public int DimensionWidth { set; get; }
        public int DimensionHeight { set; get; }
    }
}