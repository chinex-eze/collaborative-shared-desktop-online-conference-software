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
                content =  "<script type=\"text/javascript\">$(\"#dialog-background\").hide(); $(\".dialog\").remove();</script>"

            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
