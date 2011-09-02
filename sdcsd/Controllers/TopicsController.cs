/*
 * Copyright (C) 2011 Ari Rokosa, Eze Chinedu, Johannes Virtanen,
 *                    Petri Tuononen, Timo Korkalainen
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
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

            return PartialView("_TopicsList", db.Topics.ToList());
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

            return PartialView("_TopicsList", db.Topics.ToList());
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