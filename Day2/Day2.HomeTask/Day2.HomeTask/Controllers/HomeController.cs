using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day2.HomeTask.Models;

namespace Day2.HomeTask.Controllers
{
    public class HomeController : BaseController 
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("ResultView", new ResultViewModel
            {
                ControllerName = "HomeController",
                ActionName = "Index"
            });
        }
    }
}