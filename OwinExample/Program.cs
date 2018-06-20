using Microsoft.Owin.Hosting;
using Microsoft.Practices.Unity.WebApi;
using Owin;
using OwinExample.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Practices.Unity;
using OwinExample.Controllers.AccountController.Structures;

namespace OwinExample
{
    internal class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = new UnityDependencyResolver(IoC.Instance);
            appBuilder.UseWebApi(config); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StartAsWebApp();
        }

        public static void StartAsWebApp()
        {
            var accountSessionManager = new AccountSessionManager();
            IoC.Instance.RegisterInstance<IAccountSessions>(accountSessionManager);
            IoC.Instance.RegisterInstance<IAccountSessionManager>(accountSessionManager);

            string server = "http://+:9994";
            Console.WriteLine(DateTime.UtcNow + ": Starting application {0}...", server);

            using (WebApp.Start<Startup>(server))
            {
                System.Threading.Thread.Sleep(-1);
            }
        }
    }
}
