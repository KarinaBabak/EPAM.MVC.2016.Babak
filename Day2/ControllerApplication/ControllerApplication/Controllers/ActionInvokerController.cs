using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllerApplication.Infrastructure;

namespace ControllerApplication.Controllers
{
    public class ActionInvokerController : Controller
    {
        // GET: ActionInvoker
        public ActionInvokerController()
        {
            this.ActionInvoker = new CustomActionInvoker();
        }
    }
}