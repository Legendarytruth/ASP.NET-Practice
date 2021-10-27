using System;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;
using ExploreCalifornia.Config;
using ExploreCalifornia.Constraints;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup(typeof(ExploreCalifornia.Startup))]
namespace ExploreCalifornia
{
    public class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; set; } = new HttpConfiguration();

        public void Configuration(IAppBuilder app)
        {
            var config = Startup.HttpConfiguration;
            ConfigureWebApi(app, config);
        }

        
        private static void ConfigureWebApi(IAppBuilder app, HttpConfiguration config)
        {
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("identity", typeof(IdConstraint));
            config.MapHttpAttributeRoutes(constraintResolver);

            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                //constraints: new {id = @"/d+"} used for when there are multiple get with different types as id: int and name:string.
            );

            //Adding a route for a get method that uses a string for name.
            //config.Routes.MapHttpRoute(
            //    name: "DefaultNameApi",
            //    routeTemplate: "api/{controller}/{name}",
            //    defaults: new { name = RouteParameter.Optional }
            //);

            app.UseWebApi(config);
        }
    }
}