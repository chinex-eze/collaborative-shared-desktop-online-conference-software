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

        //
        // GET: /Topics/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Topics/Create

        [HttpPost]
        public ActionResult Create(TopicModel topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");  
            }

            return View(topic);
        }
        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}