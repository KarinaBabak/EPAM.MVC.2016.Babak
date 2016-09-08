using Day2.HomeTask.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day2.HomeTask.Controllers
{
    public class AdminController : BaseController
    {
        [Local]
        public ActionResult Index()
        {
            ViewBag.Controller = "AdminController";
            ViewBag.Action = "Index";
            return View("ActionInfo");
        }

        [Local]
        public ActionResult RemoveAllUsers()
        {
            UserRepository.Clear();
            return View("DisplayUserList", UserRepository.GetUsers());
        }
    }
}