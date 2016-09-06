using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day2.HomeTask.Models;
using System.Threading.Tasks;

namespace Day2.HomeTask.Controllers
{

    public class UserCustomerController : BaseController //Controller
    {       
        [HttpPost]
        //[ActionName("Add-User")]
        public async Task<ActionResult> AddUser()
        {
            await Task.Factory.StartNew(()=>UserRepository.AddAsync());
            return RedirectToAction("User-List");
        }

        [HttpGet]
        //[ActionName("User-List")]
        public ActionResult GetUserList()
        {
            var users = UserRepository.GetUsers();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}