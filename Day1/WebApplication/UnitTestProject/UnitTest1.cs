using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Machine.Specifications;
using System.Web.Routing;
using WebApplication;

namespace UnitTestProject
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
}
