using Microsoft.Owin.Hosting;
using Owin;
using OwinExample.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

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
            string server = "http://+:9994";

            Console.WriteLine(DateTime.UtcNow + ": Starting application {0}...", server);

            using (WebApp.Start<Startup>(server))
            {
                System.Threading.Thread.Sleep(-1);
            }
        }
    }
}
