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

        private DesktopItemModelDBContext _db = new DesktopItemModelDBContext();

        public ActionResult Index()
        {
            var items = _db.DesktopItems.ToList<DesktopItemModel>();
            return View(items);
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

        [HttpPost]
        public JsonResult Upload(int id, string qqfile)
        {
            var data = new
            {
                success =  true,
                complete = true

            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
