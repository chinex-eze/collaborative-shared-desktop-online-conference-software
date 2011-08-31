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
            DesktopDB _db = new DesktopDB();
            var model = _db.DesktopModels;
            return View(model);
        }
        /*
        public ViewResult _Desktop()
        {
            DesktopDB _db = new DesktopDB();
            var model = _db.DesktopModels;
            return View(model);
        }
        */
    }
} 
