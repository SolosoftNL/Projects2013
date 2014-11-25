using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_LiveSessions.Controllers
{
    public class DynamicController : Controller
    {
        // GET: Dynamic
        public ActionResult Index(string naam="Ronald")
        {
            ViewBag.Greeting = (DateTime.Now.Hour< 12) ? "Goedemorgen" : "Goedemiddag" + Environment.NewLine + naam; 
	
            return View();
        }

        public ActionResult Goto(string gotoUrl)
        {

            return RedirectPermanent(gotoUrl);
        }


    }
}