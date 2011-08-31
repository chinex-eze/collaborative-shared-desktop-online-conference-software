using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sdcsd.Controllers
{
    public class ChatController : Controller
    {
        //
        // GET: /Chat/

        public ActionResult Index()
        {
            return View();
        }

        public string getMessage(int Num)
        {
            //List<Category> categories = northwind.GetCategories();
            ///return View(categories);
            return "some messages...";
        }

        public void sendMessage(string message)
        {
            
        }
    }
}
