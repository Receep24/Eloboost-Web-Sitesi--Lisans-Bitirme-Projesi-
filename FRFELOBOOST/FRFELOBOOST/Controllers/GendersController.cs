using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FRFELOBOOST.Models;

namespace FRFELOBOOST.Controllers
{
    public class GendersController : Controller
    {
        private FRF_ELOBOOSTEntities db = new FRF_ELOBOOSTEntities();

        
        public ActionResult Index()
        {
            return View(db.Genders.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genders genders = db.Genders.Find(id);
            if (genders == null)
            {
                return HttpNotFound();
            }
            return View(genders);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenderID,GenderName")] Genders genders)
        {
            if (ModelState.IsValid)
            {
                db.Genders.Add(genders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genders);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genders genders = db.Genders.Find(id);
            if (genders == null)
            {
                return HttpNotFound();
            }
            return View(genders);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenderID,GenderName")] Genders genders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genders);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genders genders = db.Genders.Find(id);
            if (genders == null)
            {
                return HttpNotFound();
            }
            return View(genders);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genders genders = db.Genders.Find(id);
            db.Genders.Remove(genders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
