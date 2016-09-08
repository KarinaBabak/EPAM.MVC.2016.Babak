using Day2.HomeTask.FactoryPart.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Day2.HomeTask.FactoryPart.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type targetType = null;
            switch (controllerName)
            {
                case "UserCustomer":
                    targetType = typeof(UserCustomerController);
                    break;                
                case "Home":
                    targetType = typeof(HomeController);
                    break;               
                case "Admin":
                    if (!requestContext.HttpContext.Request.IsLocal)
                    {
                        throw new AccessViolationException();
                    }

                    targetType = typeof(AdminController);
                    break;
                default:
                    requestContext.RouteData.Values["controller"] = "Home";
                    targetType = typeof(HomeController);
                    break;
            }

            return targetType == null ? null : (IController)DependencyResolver.Current.GetService(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            if (controllerName.Equals("Home"))
            {
                return SessionStateBehavior.Disabled;
            }
            else
            {
                return SessionStateBehavior.Default;
            }
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}