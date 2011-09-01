using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sdcsd.Controllers
{
    public class DesktoplistController : Controller
    {
        //
        // GET: /Desktoplist/

        public ActionResult Index()
        {
            ViewBag.login = false;
            if (Response.Cookies.Get("loggedin").Value == "true")
                ViewBag.login = true;

            if (ViewBag.login)
                return View();
            else
                return null;
        }

    }
}
