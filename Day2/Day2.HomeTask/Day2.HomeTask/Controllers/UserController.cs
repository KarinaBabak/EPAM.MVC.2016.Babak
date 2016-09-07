using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day2.HomeTask.Models;
using System.Threading.Tasks;

namespace Day2.HomeTask.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<UserRepository> AddUser(UserViewModel newUser)
        //{
        //    if (newUser == null)
        //        throw new NullReferenceException("User is not exist");

        //    UserRepository repository = new UserRepository();
        //    repository.Add(newUser);
            
        //}
    }
}