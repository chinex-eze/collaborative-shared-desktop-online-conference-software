using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sdcsd.Controllers
{
    public class HeaderController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.login = false;
            if (Session["loggedin"] == "true")
                ViewBag.login = true;

            return View();
        }

    }
}
