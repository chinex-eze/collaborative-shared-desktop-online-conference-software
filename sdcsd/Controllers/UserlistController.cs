using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sdcsd.Models;

namespace sdcsd.Controllers
{
    public class UserlistController : Controller
    {
        private UserDBContext db = new UserDBContext();

        //
        // GET: /Userlist/


        public ActionResult Index()
        {
            ViewBag.login = false;
            if (Response.Cookies.Get("loggedin").Value == "true")
                ViewBag.login = true;

            if (ViewBag.login)
                return View(db.UsersDB.ToList());
            else
                return null;
        }       
    }
}
