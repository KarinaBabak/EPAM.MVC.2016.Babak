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
            controller = "Home";
            action = "index";
        };

        Because of = () =>
        {
            result = routes.GetRouteData(TestHelper.CreateHttpContext("~/Home/index/"));
        };

        It route_should_match = () => TestHelper.TestIncomingRouteResult(result, controller, action).ShouldBeTrue();
        
    }

    [Subject("Home_Routing")]
    public class When_AdditionalHomeController_AnotherIndex_called
    {
        private static RouteCollection routes;
        private static RouteData result;
        private static string controller;
        private static string action;
        private static string url;
        
        Establish context = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            controller = "Home";
            action = "AnotherIndex";
            url = "~/Additional/Home/AnotherIndex/505";
        };

        Because of = () =>
        {
            result = routes.GetRouteData(TestHelper.CreateHttpContext(url));
        };

        It route_should_match = () => TestHelper.TestIncomingRouteResult(result, controller, action).ShouldBeTrue();

    }
}
