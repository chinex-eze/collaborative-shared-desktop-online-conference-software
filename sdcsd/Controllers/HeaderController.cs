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
            if (Response.Cookies.Get("loggedin").Value == "true")
                ViewBag.login = true;

            return View();
        }

    }
}
