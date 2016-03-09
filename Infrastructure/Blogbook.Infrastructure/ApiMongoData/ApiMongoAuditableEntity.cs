namespace Blogbook.Infrastructure.ApiMongoData
{
    public abstract class ApiMongoAuditableEntity : ApiMongoEntity
    {
        public Audit Audit { get; set; }

        public ApiMongoAuditableEntity()
        {
            Audit = new Audit {Created = new AuditTerm(), Modified = new AuditTerm()};
        }

        public void SetAudit(AuditTerm audit)
        {
            if(audit==null) return;

            if (Audit == null) Audit = new Audit();
            if (Audit.Created == null)
            {
                Audit.Created=new AuditTerm
                {
                    By = audit.By,
                    On = audit.On
                };
            }

            if (Audit.Modified == null) Audit.Modified = new AuditTerm();

            Audit.Modified.By = audit.By;
            Audit.Modified.On = audit.On;
        }
    }
}

