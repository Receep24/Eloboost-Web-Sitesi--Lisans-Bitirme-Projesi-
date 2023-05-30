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
    public class AdvertsController : Controller
    {
        private FRF_ELOBOOSTEntities db = new FRF_ELOBOOSTEntities();

        
        public ActionResult Index()
        {
            var adverts = db.Adverts.Include(a => a.Elooboster).Include(a => a.Games).Include(a => a.Ranks);
            return View(adverts.ToList());
        }
        public ActionResult Adminİlan()
        {
            var adverts = db.Adverts.Include(a => a.Elooboster).Include(a => a.Games).Include(a => a.Ranks);
            return View(adverts.ToList());
        }
        public ActionResult MusteriIndex()
        {
            var adverts = db.Adverts.Include(a => a.Elooboster).Include(a => a.Games).Include(a => a.Ranks);
            return View(adverts.ToList());
        }
        public ActionResult EloboosterIndex()
        {
            var adverts = db.Adverts.Include(a => a.Elooboster).Include(a => a.Games).Include(a => a.Ranks);
            return View(adverts.ToList());
        }



        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adverts adverts = db.Adverts.Find(id);
            if (adverts == null)
            {
                return HttpNotFound();
            }
            return View(adverts);
        }

        
        public ActionResult Create()
        {
            ViewBag.EloobosterID = new SelectList(db.Elooboster, "EloobosterID", "username");
            ViewBag.GamesID = new SelectList(db.Games, "GamesID", "GamesName");
            ViewBag.RankID = new SelectList(db.Ranks, "RankID", "RankName");
            return View();
        }
        public ActionResult MusteriCreate()
        {
            ViewBag.EloobosterID = new SelectList(db.Elooboster, "EloobosterID", "username");
            ViewBag.GamesID = new SelectList(db.Games, "GamesID", "GamesName");
            ViewBag.RankID = new SelectList(db.Ranks, "RankID", "RankName");
            return View();
        }
        public ActionResult EloboosterCreate()
        {
           
            ViewBag.EloobosterID = new SelectList(db.Elooboster, "EloobosterID", "username");
            ViewBag.GamesID = new SelectList(db.Games, "GamesID", "GamesName");
            ViewBag.RankID = new SelectList(db.Ranks, "RankID", "RankName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdvertsID,EloobosterID,GamesID,RankID,AdvertTitle,AdvertDate")] Adverts adverts)
        {
            if (ModelState.IsValid)
            {
                db.Adverts.Add(adverts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EloobosterID = new SelectList(db.Elooboster, "EloobosterID", "username", adverts.EloobosterID);
            ViewBag.GamesID = new SelectList(db.Games, "GamesID", "GamesName", adverts.GamesID);
            ViewBag.RankID = new SelectList(db.Ranks, "RankID", "RankName", adverts.RankID);
            return View(adverts);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MusteriCreate([Bind(Include = "AdvertsID,EloobosterID,GamesID,RankID,AdvertTitle,AdvertDate")] Adverts adverts)
        {
            if (ModelState.IsValid)
            {
                db.Adverts.Add(adverts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EloobosterID = new SelectList(db.Elooboster, "EloobosterID", "username", adverts.EloobosterID);
            ViewBag.GamesID = new SelectList(db.Games, "GamesID", "GamesName", adverts.GamesID);
            ViewBag.RankID = new SelectList(db.Ranks, "RankID", "RankName", adverts.RankID);
            return View(adverts);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EloboosterCreate([Bind(Include = "AdvertsID,EloobosterID,GamesID,RankID,AdvertTitle,AdvertDate")] Adverts adverts)
        {
            if (ModelState.IsValid)
            {
                db.Adverts.Add(adverts);
                db.SaveChanges();
                return RedirectToAction("EloboosterIndex");
            }

            ViewBag.EloobosterID = new SelectList(db.Elooboster, "EloobosterID", "username", adverts.EloobosterID);
            ViewBag.GamesID = new SelectList(db.Games, "GamesID", "GamesName", adverts.GamesID);
            ViewBag.RankID = new SelectList(db.Ranks, "RankID", "RankName", adverts.RankID);
            return View(adverts);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adverts adverts = db.Adverts.Find(id);
            if (adverts == null)
            {
                return HttpNotFound();
            }
            ViewBag.EloobosterID = new SelectList(db.Elooboster, "EloobosterID", "username", adverts.EloobosterID);
            ViewBag.GamesID = new SelectList(db.Games, "GamesID", "GamesName", adverts.GamesID);
            ViewBag.RankID = new SelectList(db.Ranks, "RankID", "RankName", adverts.RankID);
            return View(adverts);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdvertsID,EloobosterID,GamesID,RankID,AdvertTitle,AdvertDate")] Adverts adverts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adverts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EloobosterID = new SelectList(db.Elooboster, "EloobosterID", "username", adverts.EloobosterID);
            ViewBag.GamesID = new SelectList(db.Games, "GamesID", "GamesName", adverts.GamesID);
            ViewBag.RankID = new SelectList(db.Ranks, "RankID", "RankName", adverts.RankID);
            return View(adverts);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adverts adverts = db.Adverts.Find(id);
            if (adverts == null)
            {
                return HttpNotFound();
            }
            return View(adverts);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adverts adverts = db.Adverts.Find(id);
            db.Adverts.Remove(adverts);
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
