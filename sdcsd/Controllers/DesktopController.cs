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
                Icon = "txt.png",
                Type = "file",
                LocX = 10,
                LocY = 10
            };
            return View(model);
        }

    }
}
