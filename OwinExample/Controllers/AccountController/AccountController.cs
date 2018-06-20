using OwinExample.Controllers.AccountController.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinExample.Controllers.AccountController
{
    public class HardcodeAccount
    {
        public string email;
        public string password;
    }

    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private static readonly HardcodeAccount[] accounts =
        {
            new HardcodeAccount(){ email = "test0@gmail.com", password = "somePassword0"},
            new HardcodeAccount(){ email = "test1@gmail.com", password = "somePassword1"},
        };

        private readonly IAccountSessionManager m_AccountSessionManager;

        public AccountController(IAccountSessionManager accountSessionManager)
        {
            m_AccountSessionManager = accountSessionManager;
        }

        [HttpGet]
        [Route("login")]
        public IHttpActionResult Login(string email, string password)
        {
            foreach (HardcodeAccount acc in accounts)
            {
                if (email == acc.email && password == acc.password)
                {
                    Guid guid = Guid.NewGuid();
                    m_AccountSessionManager.AddSession(guid.ToString(), new AuthData(email));

                    return new AuthResult(guid.ToString(), this);
                }
            }

            return Json(false);
        }

        [HttpGet]
        [Route("logout")]
        public IHttpActionResult Logout()
        {
            string token = ActionContext.Request.GetAccessToken();

            if (!m_AccountSessionManager.ContainsSession(token))
                return Json(false);

            m_AccountSessionManager.RemoveSession(token);

            return Json(true);
        }
    }
}