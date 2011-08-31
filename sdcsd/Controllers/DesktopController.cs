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

        DesktopItemDB _db = new DesktopItemDB(); 

        public ActionResult Index()
        {
            var model = _db.DesktopModels;
            return View(model);
        }

        public ActionResult GetPdf(string filename)
        {
            return File(filename, "application/pdf", Server.UrlEncode(filename));
        }

    }
}
