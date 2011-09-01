﻿using System;
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
            return View();
        }

        public ActionResult Login(string username)
        {
            foreach (var item in db.UsersDB.ToList())
            {
                if (item.UserName.Equals(username))
                {
                    // user is authorized
                    return View();
                }
            }
            return View("Edit");
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
    }
}