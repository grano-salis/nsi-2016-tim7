using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ETFSjedniceWeb.Controllers
{   
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            
        }

        public ActionResult ZakaziSjednicu()
        {
            return View();

        }

        public ActionResult Ucesnici()
        {
            return View();

        }

       public ActionResult Zapisnik()
        {
            return View();
        }

       public ActionResult PrikazSjednica()
       {
           return View();
       }
        
    }
}