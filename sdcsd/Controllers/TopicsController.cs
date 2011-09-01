using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sdcsd.Models;

namespace sdcsd.Controllers
{ 
    public class TopicsController : Controller
    {
        private TopicDBContext db = new TopicDBContext();
        
        //
        // GET: /Topics/

        public ViewResult Index()
        {
            ViewBag.login = false;
            if (Session["loggedin"] == "true")
                ViewBag.login = true;

            if (ViewBag.login)
                return View(db.Topics.ToList());
            else
                return null;

        }

        public ActionResult SetInactive(int id)
        {
            ViewBag.login = false;
            if (Session["loggedin"] == "true")
                ViewBag.login = true;

            TopicModel topic = db.Topics.Find(id);
            topic.IsActive = false;
            db.SaveChanges();
            return View("Notification");
        }

        [HttpPost]
        public ActionResult AddTopic(string content)
        {
            // TODO: validate received data from form

            if (content.Length > 3)
            {
                TopicModel topic = new TopicModel()
                {
                    Content = content,
                    IsActive = true,
                };

                db.Topics.Add(topic);
                db.SaveChanges();
            }

            return View("Notification");
        }

        [HttpPost]
        public ActionResult RenderTopicsHttpPost()
        {
            //return View(db.Topics.ToList());
            return PartialView("_TopicsList", db.Topics.ToList());
        }

        public ActionResult RenderTopics()
        {
            //return View(db.Topics.ToList());
            return PartialView("_TopicsList", db.Topics.ToList());
        }
                        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}