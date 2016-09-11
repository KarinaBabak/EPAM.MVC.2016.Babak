using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Data;
using Models.Models;

namespace Models.Controllers
{
    public class HomeController : Controller
    {
	    private readonly IPersonRepo _repo;

	    public HomeController(IPersonRepo personRepo)
	    {
		    _repo = personRepo;
	    }

        public ActionResult Index(int id = 1)
        {
	        var person = _repo.GetAll().First(p => p.PersonId == id);
			return View(person);
        }

        [HttpGet]
        public ActionResult CreatePerson()
        {
            return View();
        }


        [HttpPost]
        [ActionName("CreatePerson")]
        public ActionResult CreatePersonPost()
        {
            Person person = new Person();

            if (TryUpdateModel(person, new FormValueProvider(this.ControllerContext)))
            {
                return View("DisplayPerson", person);
            }

            return View("Index");
        }

        public ActionResult DisplayPerson(Person person)
        {
            return View(person);
        }

        public ActionResult DisplaySummary(
            [Bind(Prefix = "HomeAddress")] Address summary)
        {
            return View(summary);
        }

        public ActionResult Names(string[] names)
        {
            names = names ?? new string[0];
            return View(names);
        }

        public ActionResult Addresses()
        {
            IList<Address> addresses = new List<Address>();
            UpdateModel(addresses);
            return View(addresses);
        }

       
    }
}