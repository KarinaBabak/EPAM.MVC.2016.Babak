using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllerApplication.Models;
using ControllerApplication.Infrastructure;

namespace ControllerApplication.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult Index()
        {
            return View("ResultView", new Result
            {
                ControllerName = "ProductController",
                ActionName = "Index"            
            });
        }


        public ActionResult List()
        {
            return View("ResultView", new Result
            {
                ControllerName = "ProductController",
                ActionName = "List"
            });
        }

    }
}