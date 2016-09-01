using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using WebApplication.App_Start;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute("AdditionalAnotherRoute", "Additional/{controller}/{action}/{id}",
            new
            {
                controller = "Home",
                action = "AnotherIndex",
                id = UrlParameter.Optional
            },           
            constraints: new { controller = "^H.*", id = @"\d{2}" },
            namespaces: new[] { "AdditionalLibrary" });


            Route homeRoute = routes.MapRoute("MyAnotherRoute", "Another/{controller}/{action}/{id}",
            new
            {
                controller = "Home",
                action = "AnotherIndex",
                id = UrlParameter.Optional
            },            
            new { id = new ExpectedValuesConstraint("songs", "books", "images") },
            namespaces: new[] { "WebApplication.Controllers" });
            homeRoute.DataTokens["UseNamespaceFallback"] = false;



            routes.MapRoute("HomeRoute", "{controller}/{action}",
            new
            {
                controller = "Home",
                action = "Index"
            },
            new { controller = "^H.*", action = "Index|^About$|Contact", httpMethod = new HttpMethodConstraint("GET") },
            namespaces: new[] { "WebApplication.Controllers" });
            


            routes.MapRoute("AdditionalRoute", "{controller}/{action}/{id}",
            new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional
            },
            new { id = new LengthRouteConstraint(2,9) },
            namespaces: new[] { "AdditionalLibrary" });



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new[] { "WebApplication.Controllers" });
        }
    }
}
