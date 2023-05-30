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
    
    public class MeetingsController : Controller
    {
        private FRF_ELOBOOSTEntities db = new FRF_ELOBOOSTEntities();

        // GET: Meetings
        public ActionResult Index()
        {
            var meetings = db.Meetings.Include(m => m.Adverts).Include(m => m.Customers).Include(m => m.Elooboster).Include(m => m.Games).Include(m => m.Ranks);
            return View(meetings.ToList());
        }

        // GET: Meetings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meetings meetings = db.Meetings.Find(id);
            if (meetings == null)
            {
                return HttpNotFound();
            }
            return View(meetings);
        }

      
        public ActionResult Create()
        {
            ViewBag.AdvertsID = new SelectList(db.Adverts, "AdvertsID", "AdvertTitle");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "username");
            ViewBag.EloobosterID = new SelectList(db.Elooboster, "EloobosterID", "username");
            ViewBag.GamesID = new SelectList(db.Games, "GamesID", "GamesName");
            ViewBag.RankID = new SelectList(db.Ranks, "RankID", "RankName");
            return View();
        }
        public ActionResult MusteriCreate()
        {
            ViewBag.AdvertsID = new SelectList(db.Adverts, "AdvertsID", "AdvertTitle");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "username");
            ViewBag.EloobosterID = new SelectList(db.Elooboster, "EloobosterID", "username");
            ViewBag.GamesID = new SelectList(db.Games, "GamesID", "GamesName");
            ViewBag.RankID = new SelectList(db.Ranks, "RankID", "RankName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MusteriCreate([Bind(Include = "MeetID,CustomerID,EloobosterID,AdvertsID,GamesID,RankID,MeetingDate")] Meetings meetings)
        {
            if (ModelState.IsValid)
            {
                db.Meetings.Add(meetings);
                db.SaveChanges();
                ViewBag.Success = true;
            }


            ViewBag.AdvertsID = new SelectList(db.Adverts, "AdvertsID", "AdvertTitle", meetings.AdvertsID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "username", meetings.CustomerID);
            ViewBag.EloobosterID = new SelectList(db.Elooboster, "EloobosterID", "username", meetings.EloobosterID);
            ViewBag.GamesID = new SelectList(db.Games, "GamesID", "GamesName", meetings.GamesID);
            ViewBag.RankID = new SelectList(db.Ranks, "RankID", "RankName", meetings.RankID);
            return View(meetings);
        }
        // POST: Meetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeetID,CustomerID,EloobosterID,AdvertsID,GamesID,RankID,MeetingDate")] Meetings meetings)
        {
            if (ModelState.IsValid)
            {
                db.Meetings.Add(meetings);
                db.SaveChanges();
                ViewBag.Success = true;
            }

            ViewBag.AdvertsID = new SelectList(db.Adverts, "AdvertsID", "AdvertTitle", meetings.AdvertsID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "username", meetings.CustomerID);
            ViewBag.EloobosterID = new SelectList(db.Elooboster, "EloobosterID", "username", meetings.EloobosterID);
            ViewBag.GamesID = new SelectList(db.Games, "GamesID", "GamesName", meetings.GamesID);
            ViewBag.RankID = new SelectList(db.Ranks, "RankID", "RankName", meetings.RankID);
            return View(meetings);
        }

        // GET: Meetings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meetings meetings = db.Meetings.Find(id);
            if (meetings == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdvertsID = new SelectList(db.Adverts, "AdvertsID", "AdvertTitle", meetings.AdvertsID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "username", meetings.CustomerID);
            ViewBag.EloobosterID = new SelectList(db.Elooboster, "EloobosterID", "username", meetings.EloobosterID);
            ViewBag.GamesID = new SelectList(db.Games, "GamesID", "GamesName", meetings.GamesID);
            ViewBag.RankID = new SelectList(db.Ranks, "RankID", "RankName", meetings.RankID);
            return View(meetings);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeetID,CustomerID,EloobosterID,AdvertsID,GamesID,RankID,MeetingDate")] Meetings meetings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdvertsID = new SelectList(db.Adverts, "AdvertsID", "AdvertTitle", meetings.AdvertsID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "username", meetings.CustomerID);
            ViewBag.EloobosterID = new SelectList(db.Elooboster, "EloobosterID", "username", meetings.EloobosterID);
            ViewBag.GamesID = new SelectList(db.Games, "GamesID", "GamesName", meetings.GamesID);
            ViewBag.RankID = new SelectList(db.Ranks, "RankID", "RankName", meetings.RankID);
            return View(meetings);
        }

        // GET: Meetings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meetings meetings = db.Meetings.Find(id);
            if (meetings == null)
            {
                return HttpNotFound();
            }
            return View(meetings);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meetings meetings = db.Meetings.Find(id);
            db.Meetings.Remove(meetings);
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
