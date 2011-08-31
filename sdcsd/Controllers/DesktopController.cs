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

        public ActionResult GetTxt(string id)
        {
            return File(id, "text/plain", Server.UrlEncode(id));
        }

        public FilePathResult GetFileFromDisk(string id)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Content/desktopFiles/";
            string fileName = id;
            return File(path + fileName, "text/plain", id);
        }

        [HttpPost]
        public ActionResult AddItem() {
            return View();
        }

    }
}
