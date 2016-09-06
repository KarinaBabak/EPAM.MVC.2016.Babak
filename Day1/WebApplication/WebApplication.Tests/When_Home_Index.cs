using System;
using Machine.Specifications;
using System.Web;
using System.Web.Routing;
using WebApplication.Controllers;

namespace WebApplication.Tests
{
    [Subject("Home_Routing")]
    public class When_HomeController_Index_called
    {     
        private static RouteCollection routes;
        private static RouteData result;
        //private static string url;
        private static string controller = "home";
        private static string action = "index";

        Establish context = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
           // url = "~/Another/Home/AnotherIndex/pictures";
        };

        Because of = () =>
        {
            result = routes.GetRouteData(TestHelper.CreateHttpContext("~/home/index/"));
        };

        It route_should_match = () => TestHelper.TestIncomingRouteResult(result, controller, action).ShouldBeTrue();
        
    }
}
