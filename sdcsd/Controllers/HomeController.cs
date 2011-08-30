using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sdcsd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About!";
            return View();
        }

        public ActionResult Page()
        {
            ViewBag.Message = "Page";
            return View();
        }
    }
} 
