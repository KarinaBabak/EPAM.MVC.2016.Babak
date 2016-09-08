using Day3.HomeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day3.HomeTask.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]        
        public ActionResult Index(Person person)
        {
            PersonRepository.Add(person);
            return RedirectToAction("DisplayPersonInfo", "Home", person);            
        }

        [HttpGet]
        public ActionResult Index()
        {            
            return View();
        }

        [HttpGet]
        public ActionResult DisplayPersonInfo(Person person)
        {
            return View(person);
        }

        [HttpGet]
        public ActionResult GetAllPersons()
        {
            return View(PersonRepository.GetPersons());
        }

        [HttpGet]
        public ActionResult DisplayHeader(Person person)
        {
            return PartialView("_header", person);
        }

        public ActionResult ChangeSide(Person person)
        {
            Person personToChange = PersonRepository.GetPersons().Where(p => p.Name == person.Name).FirstOrDefault();
            personToChange.ChangeSide();
            return View("DisplayPersonInfo", personToChange);
        }

        

    }
}