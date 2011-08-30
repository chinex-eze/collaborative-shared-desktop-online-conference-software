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
        // GET: /Topics/Details/5

        public ViewResult Details(int id)
        {
            Topic topic = db.Topics.Find(id);
            return View(topic);
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
        public ActionResult Create(Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(topic);
        }
        
        //
        // GET: /Topics/Edit/5
 
        public ActionResult Edit(int id)
        {
            Topic topic = db.Topics.Find(id);
            return View(topic);
        }

        //
        // POST: /Topics/Edit/5

        [HttpPost]
        public ActionResult Edit(Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        //
        // GET: /Topics/Delete/5
 
        public ActionResult Delete(int id)
        {
            Topic topic = db.Topics.Find(id);
            return View(topic);
        }

        //
        // POST: /Topics/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Topic topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}