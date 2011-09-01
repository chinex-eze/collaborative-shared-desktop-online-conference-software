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
            ViewBag.login = false;
            if (Session["loggedin"] == "true")
                ViewBag.login = true;

            if(ViewBag.login)
            	return View(db.Messages.ToList());
            else
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult SendMessage(string message)
        {
            // TODO: validate received data from form

            if (message.Length > 3 && message.Length < 160)
            {
                MessageModel msg = new MessageModel()
                {
                    Sender = Session["user"].ToString(),
                    Content = message,
                    TimeSent = DateTime.Now,
                };

                db.Messages.Add(msg);
                db.SaveChanges();
            }
            return PartialView("_ChatMessageList", db.Messages.ToList());
        }

        [HttpPost]
        public ActionResult RenderMessagesHttpPost()
        {
            return PartialView("_ChatMessageList", db.Messages.ToList());
        }
        
        // TODO: should override Dispose
    }
}
