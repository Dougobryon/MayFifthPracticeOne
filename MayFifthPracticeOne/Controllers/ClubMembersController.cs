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
    public class ClubMembersController : Controller
    {
        private MayFifthPracticeOneContext db = new MayFifthPracticeOneContext();

        // GET: ClubMembers
        public ActionResult Index()
        {
            return View(db.ClubMembers.ToList());
        }

        // GET: ClubMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubMembers clubMembers = db.ClubMembers.Find(id);
            if (clubMembers == null)
            {
                return HttpNotFound();
            }
            return View(clubMembers);
        }

        // GET: ClubMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClubMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberID,FirstName,LastName,Sex")] ClubMembers clubMembers)
        {
            if (ModelState.IsValid)
            {
                db.ClubMembers.Add(clubMembers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clubMembers);
        }

        // GET: ClubMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubMembers clubMembers = db.ClubMembers.Find(id);
            if (clubMembers == null)
            {
                return HttpNotFound();
            }
            return View(clubMembers);
        }

        // POST: ClubMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberID,FirstName,LastName,Sex")] ClubMembers clubMembers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubMembers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clubMembers);
        }

        // GET: ClubMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubMembers clubMembers = db.ClubMembers.Find(id);
            if (clubMembers == null)
            {
                return HttpNotFound();
            }
            return View(clubMembers);
        }

        // POST: ClubMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClubMembers clubMembers = db.ClubMembers.Find(id);
            db.ClubMembers.Remove(clubMembers);
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
