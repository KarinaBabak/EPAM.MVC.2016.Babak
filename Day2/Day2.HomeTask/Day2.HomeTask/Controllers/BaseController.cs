using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Day2.HomeTask.Controllers
{
    public abstract class BaseController : Controller
    {      
        protected override void HandleUnknownAction(string actionName)
        {            
            try
            {
                this.View(actionName).ExecuteResult(this.ControllerContext);
            }
            catch (InvalidOperationException ex)
            {                
                this.View("Error404").ExecuteResult(this.ControllerContext);
            }
        }
      
    }
}