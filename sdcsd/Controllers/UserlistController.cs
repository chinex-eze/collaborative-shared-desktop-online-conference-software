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
            // just for testing 
            UserModel user = new UserModel()
            {
                UserName = "ari",
                LastSeen = DateTime.Now,
            };

            db.UsersDB.Add(user);
            db.SaveChanges();
            

            return View(db.UsersDB.ToList());
        }       

        public ActionResult Edit()
        {
            return View();
        }
    }
}
