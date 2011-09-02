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
            Session["loggedin"] = "false";
            if (db.UsersDB.Count(u => u.UserName == username) > 0)
            {
                if(db.UsersDB.First(u => u.UserName == username).PassWord == password)
                {
                    Session["loggedin"] = "true";
                    Session["user"] = username;
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session["loggedin"] = "false";
            Session["user"] = "guest";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddNewUserToDb(string userName, string passWord)
        {
            UserModel user = new UserModel();
            user.UserName = userName;
            user.PassWord = passWord;
            user.LastSeen = System.DateTime.Now;

            db.UsersDB.Add(user);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
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
