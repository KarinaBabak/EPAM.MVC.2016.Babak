using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AdditionalLibrary
{
    public class HomeController : Controller
    {       
        //[HttpGet]
        public ActionResult Index(string id = "Default Id")
        {            
            string data = "Json Result from Additional controller";

            return Json(data, JsonRequestBehavior.AllowGet);     
        }

        //[HttpGet]
        public ActionResult AnotherIndex(string id = "Default Id")
        {            
            string data = "AnotherIndex from Additional controller: ID = " + id;

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
