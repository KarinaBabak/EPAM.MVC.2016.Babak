using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            namespaces: new[] { "WebApplication.Controllers" });


            routes.MapRoute("AdditionalRoute", "{controller}/{action}/{id}",
            new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional
            },
            namespaces: new[] { "AdditionalLibrary" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new[] { "WebApplication.Controllers" });
        }
    }
}
