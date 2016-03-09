using System;
using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Api.Web.Domain.Sessions
{
    public static class SessionHelper
    {
        public static string GetUserLogin()
        {
            return "UsuarioDefinido";
        }

        public static AuditTerm GetAudit()
        {
            return new AuditTerm
            {
                By = GetUserLogin(),
                On = DateTime.UtcNow
            };
        }
    }
}