using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sdcsd.Controllers
{
    public class HeaderController : Controller
    {
        public ActionResult Update()
        {
            return PartialView("_Header");
        }

    }
}
