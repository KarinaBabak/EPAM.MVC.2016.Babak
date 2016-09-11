﻿using Day2.HomeTask.FactoryPart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day2.HomeTask.FactoryPart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Result", new ResultViewModel
            {
                ControllerName = "HomeController",
                ActionName = "Index"
            });
        }
    }
}