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
            return View(db.Topics.ToList());
        }

        public ActionResult SetInactive(int id)
        {
            TopicModel topic = db.Topics.Find(id);
            topic.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult AddTopic(string content)
        {
            // TODO: validate received data from form

            TopicModel topic = new TopicModel()
            {
                Content = content,
                IsActive = true,
            };

            db.Topics.Add(topic);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
                        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}