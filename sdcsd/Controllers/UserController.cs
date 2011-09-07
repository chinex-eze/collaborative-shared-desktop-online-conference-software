/***********************************************************************
 * Copyright (C) 2011 Ari Rokosa, Chinedu Eze, Johannes Virtanen,
 *                    Petri Tuononen, Timo Korkalainen
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 ***********************************************************************/
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
            //check if user name is already in the database
            if (db.UsersDB.Count(i => i.UserName == userName) > 0)
            {
                return View();
            }
            else
            {
                UserModel user = new UserModel();
                user.UserName = userName;
                user.PassWord = passWord;
                user.LastSeen = System.DateTime.Now;

                db.UsersDB.Add(user);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult DeleteUser(string userName)
        {
            if (db.UsersDB.Count(i => i.UserName == userName) > 0)
            {
                UserModel item = db.UsersDB.First(i => i.UserName == userName);
                db.UsersDB.Remove(item);
                db.SaveChanges();
            }

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
