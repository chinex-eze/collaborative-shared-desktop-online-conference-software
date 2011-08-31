using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sdcsd.Models;

namespace sdcsd.Controllers
{
    public class DesktopController : Controller
    {
        //
        // GET: /Desktop/

        DesktopDB _db = new DesktopDB(); 

        public ActionResult Index()
        {
            var model = _db.DesktopModels;
            return View(model);
        }

    }
}
