namespace Blogbook.Infrastructure.ApiMongoData
{
    public class Audit
    {
        public AuditTerm Created { set; get; }
        public AuditTerm Modified { set; get; }
    }
}