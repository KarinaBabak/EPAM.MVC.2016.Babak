using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Day2.HomeTask.FactoryPart
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("User", "User/{action}",
            new
            {
                controller = "UserCustomer",
                action = "Index"
            });

            routes.MapRoute("Customer", "Customer/{action}",
            new
            {
                controller = "UserCustomer",
                action = "Index"
            });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
