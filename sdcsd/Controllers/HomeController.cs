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

            Response.Cookies.Add(new HttpCookie("loggedin", "true") { Expires = DateTime.Now.AddHours(2) });

            if (Response.Cookies.Get("loggedin").Value == "true")
            {
                ViewBag.login = true;
                Response.Cookies.Add(new HttpCookie("user", "testaaja") { Expires = DateTime.Now.AddHours(2) });
            }

            return View();
        }
    }
}