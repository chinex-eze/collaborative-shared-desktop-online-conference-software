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
            DesktopItemDB _db = new DesktopItemDB();
            var model = _db.DesktopModels;
            return View(model);
        }
    }
} 
