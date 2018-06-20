using OwinExample.Controllers.AccountController.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinExample.Controllers
{
    [RoutePrefix("api/test")]
    [AuthorizeOwinExample(Roles = "admin,user")]
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("generatestring")]
        public IHttpActionResult GenerateString()
        {
            return Json("Hello World");
        }
    }
}