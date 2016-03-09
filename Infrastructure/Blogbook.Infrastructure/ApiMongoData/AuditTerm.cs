using System;

namespace Blogbook.Infrastructure.ApiMongoData
{
    public class AuditTerm
    {
        public DateTime On { set; get; }
        public string By { set; get; }
    }
}
