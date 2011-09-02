using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Routing;
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
   
        public ActionResult AddItem()
        {
            if(Session["loggedin"] == "true")
                return View();

            return null;
        }

        [HttpPost]
        public string UpdateLocation(string name, string locX, string locY)
        {
            if (_db.DesktopItems.Count(i => i.Name == name) > 0)
            {
                DesktopItemModel item = _db.DesktopItems.First(i => i.Name == name);
                item.LocX = locX;
                item.LocY = locY;
                _db.SaveChanges();
            }

            return "";
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

                DesktopItemModel uusi = new DesktopItemModel();
                uusi.LocX = "45%";
                uusi.LocY = "45%";
                uusi.Name = qqfile;
                uusi.DesktopID = 1;
                uusi.ID = 4;

                _db.DesktopItems.Add(uusi);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, "application/json");
            }

            return Json(new { success = true }, "text/html");
        }

    }
}
