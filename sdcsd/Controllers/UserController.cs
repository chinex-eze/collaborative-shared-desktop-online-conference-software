using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sdcsd.Models;

namespace sdcsd.Controllers
{
    public class UserController : Controller
    {
        private UserDBContext db = new UserDBContext();

        //
        // GET: /UserLogin/

        public ActionResult Index()
        {
            ViewBag.login = false;
            if (Session["loggedin"] == "true")
                ViewBag.login = true;

            if (ViewBag.login)
                return View();
            else
                return null;
        }

        public ActionResult Login(string username, string password)
        {
            foreach (var item in db.UsersDB.ToList())
            {
                if (item.UserName.Equals(username))
                {
                    // user is authorized
                }
            }
            Session["loggedin"] = "true";
            return RedirectToAction("Index","Home");
        }

        public ActionResult Logout()
        {
            Session["loggedin"] = "false";
            Session["user"] = "guest";
            return RedirectToAction("Index", "Home");
        }

        public void AddNewUserToDb(string userName, string passWord)
        {
            UserModel user = new UserModel()
            {
                UserName = userName,
                PassWord = passWord,
                LastSeen = DateTime.Now,
            };
            db.UsersDB.Add(user);
        }

        public ActionResult Edit()
        {
            ViewBag.login = false;
            if (Session["loggedin"] == "true")
                ViewBag.login = true;

            if (ViewBag.login == true)
                return View();
            else
                return View("LoginBox");
        }
    }
}
