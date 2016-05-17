using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MayFifthPracticeOne.Models;

namespace MayFifthPracticeOne.Controllers
{
    public class ParticipationOfferingsController : Controller
    {
        private MayFifthPracticeOneContext db = new MayFifthPracticeOneContext();

        // GET: ParticipationOfferings
        public ActionResult Index()
        {
            var participationOfferings = db.ParticipationOfferings.Include(p => p.ClubMember).Include(p => p.FitnessOffering);
            return View(participationOfferings.ToList());
        }

        // GET: ParticipationOfferings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipationOfferings participationOfferings = db.ParticipationOfferings.Find(id);
            if (participationOfferings == null)
            {
                return HttpNotFound();
            }
            return View(participationOfferings);
        }

        // GET: ParticipationOfferings/Create
        public ActionResult Create()
        {
            ViewBag.MemberID = new SelectList(db.ClubMembers, "MemberID", "FirstName");
            ViewBag.GroupID = new SelectList(db.FitnessOfferings, "GroupID", "GroupTraining");
            return View();
        }

        // POST: ParticipationOfferings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParticpationID,GroupID,MemberID")] ParticipationOfferings participationOfferings)
        {
            if (ModelState.IsValid)
            {
                db.ParticipationOfferings.Add(participationOfferings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberID = new SelectList(db.ClubMembers, "MemberID", "FirstName", participationOfferings.MemberID);
            ViewBag.GroupID = new SelectList(db.FitnessOfferings, "GroupID", "GroupTraining", participationOfferings.GroupID);
            return View(participationOfferings);
        }

        // GET: ParticipationOfferings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipationOfferings participationOfferings = db.ParticipationOfferings.Find(id);
            if (participationOfferings == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.ClubMembers, "MemberID", "FirstName", participationOfferings.MemberID);
            ViewBag.GroupID = new SelectList(db.FitnessOfferings, "GroupID", "GroupTraining", participationOfferings.GroupID);
            return View(participationOfferings);
        }

        // POST: ParticipationOfferings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParticpationID,GroupID,MemberID")] ParticipationOfferings participationOfferings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participationOfferings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberID = new SelectList(db.ClubMembers, "MemberID", "FirstName", participationOfferings.MemberID);
            ViewBag.GroupID = new SelectList(db.FitnessOfferings, "GroupID", "GroupTraining", participationOfferings.GroupID);
            return View(participationOfferings);
        }

        // GET: ParticipationOfferings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipationOfferings participationOfferings = db.ParticipationOfferings.Find(id);
            if (participationOfferings == null)
            {
                return HttpNotFound();
            }
            return View(participationOfferings);
        }

        // POST: ParticipationOfferings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParticipationOfferings participationOfferings = db.ParticipationOfferings.Find(id);
            db.ParticipationOfferings.Remove(participationOfferings);
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
