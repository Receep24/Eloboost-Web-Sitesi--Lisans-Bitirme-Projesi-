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
    public class EloobostersController : Controller
    {
        private FRF_ELOBOOSTEntities db = new FRF_ELOBOOSTEntities();

        
        public ActionResult Index()
        {
            var elooboster = db.Elooboster.Include(e => e.Genders);
            return View(elooboster.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elooboster elooboster = db.Elooboster.Find(id);
            if (elooboster == null)
            {
                return HttpNotFound();
            }
            return View(elooboster);
        }

        
        public ActionResult Create()
        {
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "GenderName");
            return View();
        }
        public ActionResult EloboosterCreate()
        {
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "GenderName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EloobosterID,username,password,usertype,FirstName,LastName,GenderID,Email")] Elooboster elooboster)
        {
            if (ModelState.IsValid)
            {
                db.Elooboster.Add(elooboster);
                db.SaveChanges();
                return RedirectToAction("Login","Kullanicilar");
            }

            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "GenderName", elooboster.GenderID);
            return View(elooboster);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EloboosterCreate([Bind(Include = "EloobosterID,username,password,usertype,FirstName,LastName,GenderID,Email")] Elooboster elooboster)
        {
            if (ModelState.IsValid)
            {
                db.Elooboster.Add(elooboster);
                db.SaveChanges();
                return RedirectToAction("Login", "Kullanicilar");
            }

            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "GenderName", elooboster.GenderID);
            return View(elooboster);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elooboster elooboster = db.Elooboster.Find(id);
            if (elooboster == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "GenderName", elooboster.GenderID);
            return View(elooboster);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EloobosterID,username,password,usertype,FirstName,LastName,GenderID,Email")] Elooboster elooboster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elooboster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "GenderName", elooboster.GenderID);
            return View(elooboster);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elooboster elooboster = db.Elooboster.Find(id);
            if (elooboster == null)
            {
                return HttpNotFound();
            }
            return View(elooboster);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Elooboster elooboster = db.Elooboster.Find(id);
            db.Elooboster.Remove(elooboster);
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
