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
            Response.Cookies.Add(new HttpCookie("loggedin", "true") { Expires = DateTime.Now.AddHours(2) });
            if (Response.Cookies.Get("loggedin").Value == "true")
            {

                return View();
            }
            else
            {
                Response.Cookies.Add(new HttpCookie("loggedin", "false") { Expires = DateTime.Now.AddHours(2) });
                return View("Public");
            }
        }
    }
} 
