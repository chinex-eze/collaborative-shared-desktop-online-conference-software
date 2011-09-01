using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sdcsd.Models;
using System.IO;
using System.Web.Routing;

namespace sdcsd.Controllers
{
    public class DesktopController : Controller
    {
        //
        // GET: /Desktop/

        private DesktopItemModelDBContext _db = new DesktopItemModelDBContext();

        public ActionResult Index()
        {
            ViewBag.login = false;
            if (Session["loggedin"] == "true")
                ViewBag.login = true;

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
        public ActionResult AddItem()
        {
            return View();
        }

        public ActionResult AddItemToDB(string id, int desktopID)
        {
            DesktopItemModel item = new DesktopItemModel()
            {
                DesktopID = desktopID, //TODO: get active desktop
                Name = id,
                LocX = "50%",
                LocY = "50%"
            };

            _db.DesktopItems.Add(item);
            _db.SaveChanges();

            return View();
        }

        [HttpPost]
        public ActionResult Upload(string qqfile)
        {
            var path = Server.MapPath("~/Content/desktopFiles");
            var file = string.Empty;

            try
            {
                var stream = Request.InputStream;
                if (String.IsNullOrEmpty(Request["qqfile"]))
                {
                    // IE
                    HttpPostedFileBase postedFile = Request.Files[0];
                    stream = postedFile.InputStream;
                    file = Path.Combine(path, System.IO.Path.GetFileName(Request.Files[0].FileName));
                }
                else
                {
                    //Webkit, Mozilla
                    file = Path.Combine(path, qqfile);
                }

                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                System.IO.File.WriteAllBytes(file, buffer);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, "application/json");
            }

            return Json(new { success = true }, "text/html");
        }

    }
}
