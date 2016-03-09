using System.Data.Entity;

namespace Blogbook.Web.Client.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
    }
}