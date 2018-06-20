using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace OwinExample.Controllers.AccountController.Structures
{
    public class AuthResult : OkNegotiatedContentResult<string>
    {
        public AuthResult(string guid, ApiController controller)
            : base(guid, controller)
        {
            m_Guid = guid;
        }

        public override async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base.ExecuteAsync(cancellationToken);

            var cookie = new CookieHeaderValue("access-token", m_Guid)
            {
                Expires = DateTimeOffset.UtcNow.AddDays(1),
                Domain = Request.RequestUri.Host,
                Path = "/"
            };

            response.Headers.AddCookies(new[] { cookie });

            return response;
        }

        private readonly string m_Guid;
    }
}
