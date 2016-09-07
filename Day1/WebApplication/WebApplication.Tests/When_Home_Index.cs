using System;
using Machine.Specifications;
using System.Web;
using System.Web.Routing;


namespace WebApplication.Tests
{
    [Subject("Home_Routing")]
    public class When_HomeController_Index_called
    {     
        private static RouteCollection routes;
        private static RouteData result;       
        private static string controller;
        private static string action;
        

        Establish context = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            controller = "home";
            action = "index";
        };

        Because of = () =>
        {
            result = routes.GetRouteData(TestHelper.CreateHttpContext("~/home/index/"));
        };

        It route_should_match = () => TestHelper.TestIncomingRouteResult(result, controller, action).ShouldBeTrue();
        
    }

    [Subject("LengthRouteConstraint_Home_Routing")]
    public class When_LengthRouteConstraint_NotChecked
    {
        private static RouteCollection routes;
        private static RouteData result;
        private static string controller;
        private static string action;
        private static string url;
        private static bool value;

        Establish context = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            controller = "home";
            action = "index";
            url = "~/home/index/a";
        };

        Because of = () =>
        {
            result = routes.GetRouteData(TestHelper.CreateHttpContext(url));
            value = (result == null || result.Route == null);
        };

        It should_not_pass = () => value.ShouldBeTrue();
    }

    [Subject("LengthRouteConstraint_Home_Routing")]
    public class When_LengthRouteConstraint_Checked
    {
        private static RouteCollection routes;
        private static RouteData result;
        private static string controller;
        private static string action;
        private static string url;
        private static bool value;

        Establish context = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            controller = "home";
            action = "index";
            url = "~/home/index/aaa";
        };

        Because of = () =>
        {
            result = routes.GetRouteData(TestHelper.CreateHttpContext(url));
            value = (result == null || result.Route == null);
        };

        It should_not_pass = () => value.ShouldBeFalse();
    }

}
