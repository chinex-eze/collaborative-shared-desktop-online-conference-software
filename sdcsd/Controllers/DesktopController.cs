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

        public ActionResult Desktop()
        {
            var model = new DesktopModel()
            {
                Name = "Minutes2010.txt",
                Icon = "/../../Content/icons/48px_txt.png",
                Type = "txt",
                LocX = "100px",
                LocY = "250px"
            };

            var model2 = new DesktopModel()
            {
                Name = "CorporateInfo.txt",
                Icon = "/../../Content/icons/48px_document.png",
                Type = "document",
                LocX = "150px",
                LocY = "300px"
            };

            HashSet<DesktopModel> Models = new HashSet<DesktopModel> { model, model2 }; 
            return View(Models);
        }

    }
}
