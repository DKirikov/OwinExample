using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OwinExample.Controllers.AccountController.Structures
{
    public static class HttpRequestMessageExtensions
    {
        private const string m_AccessTokenKey = "access-token";
        private const string m_AccountIdKey = "account-id";

        public static string GetAccessToken(this HttpRequestMessage request)
        {
            var cookieHeaderValue = request.Headers.GetCookies(m_AccessTokenKey).FirstOrDefault();

            if (cookieHeaderValue != null)
                return cookieHeaderValue[m_AccessTokenKey].Value;

            return null;
        }

        public static string GetAccountId(this HttpRequestMessage request)
        {
            var cookieHeaderValue = request.Headers.GetCookies(m_AccountIdKey).FirstOrDefault();

            if (cookieHeaderValue != null)
                return cookieHeaderValue[m_AccountIdKey].Value;

            return null;
        }
    }
}
