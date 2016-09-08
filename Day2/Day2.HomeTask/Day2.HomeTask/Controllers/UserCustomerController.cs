using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day2.HomeTask.Models;
using System.Threading.Tasks;
using Day2.HomeTask.Infrastructure;

namespace Day2.HomeTask.Controllers
{
    public class UserCustomerController : BaseController 
    {
        public ActionResult Index()
        {
            ViewBag.Controller = "AdminController";
            ViewBag.Action = "Index";
            return View("ActionInfo");
        }

        [HttpPost]
        [ActionName("Add-User")]
        public async Task<ActionResult> AddUser(UserViewModel user)
        {
            await Task.Factory.StartNew(()=>UserRepository.AddAsync(user));
            return RedirectToAction("User-List");
        }

        [ActionName("Add-User")]
        [HttpGet]
        public ActionResult Add()
        {
            return View("AddUser");
        }

        [HttpPost]
        [ActionName("User-List")]
        public ActionResult GetUserList()
        {
            var users = UserRepository.GetUsers();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("User-List")]
        public ActionResult DisplayUserList()
        {
            return View("DisplayUserList", UserRepository.GetUsers());
        }
    }
}