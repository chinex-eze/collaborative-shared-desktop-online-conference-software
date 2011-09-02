using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sdcsd.Models;

namespace sdcsd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.login = false;

            if (Session["loggedin"] == "true")
            {
                ViewBag.login = true;
            }

            return View();
        }
    }
}