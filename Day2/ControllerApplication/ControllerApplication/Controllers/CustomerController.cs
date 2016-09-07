﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllerApplication.Models;

namespace ControllerApplication.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View("ResultView", new Result
            {
                ControllerName = "CustomerController",
                ActionName = "Index"
            });
        }

        public ActionResult List()
        {
            return View("ResultView", new Result
            {
                ControllerName = "CustomerController",
                ActionName = "List"
            });
        }
    }
}