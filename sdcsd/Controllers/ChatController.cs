using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sdcsd.Models;

namespace sdcsd.Controllers
{
    public class ChatController : Controller
    {
        private MessageDBContext db = new MessageDBContext();

        //
        // GET: /Chat/

        public ActionResult Index()
        {
            return View(db.Messages.ToList());
        }

        [HttpPost]
        public ActionResult SendMessage(string message)
        {
            // TODO: validate received data from form

            MessageModel msg = new MessageModel()
            {
                Sender = Response.Cookies.Get("user").Value,
                Content = message,
                TimeSent = DateTime.Now,
            };

            db.Messages.Add(msg);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult RenderMessagesHttpPost()
        {
            return PartialView("_ChatMessageList", db.Messages.ToList());
        }
        
        // TODO: should override Dispose
    }
}
