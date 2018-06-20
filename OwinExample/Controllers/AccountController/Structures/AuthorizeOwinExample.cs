using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

///////////////////////////
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http.Results;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;

namespace OwinExample.Controllers.AccountController.Structures
{
    public class AuthorizeOwinExample : AuthorizeAttribute
    {
        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {
                string token = actionContext.Request.GetAccessToken();

                AuthData auth = IoC.Instance.Resolve<IAccountSessions>().GetAuthData(token);

                if (auth != null)
                {
                    if (Roles.Contains(auth.Role) && auth.IsValid())
                    {
                        auth.Extend();
                        return true;
                    }
                }
            }
            catch
            { }

            return false;
        }
    }
}
