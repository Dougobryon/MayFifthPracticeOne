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
    public class FitnessOfferingsController : Controller
    {
        private MayFifthPracticeOneContext db = new MayFifthPracticeOneContext();

        // GET: FitnessOfferings
        public ActionResult Index()
        {
            return View(db.FitnessOfferings.ToList());
        }

        // GET: FitnessOfferings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessOfferings fitnessOfferings = db.FitnessOfferings.Find(id);
            if (fitnessOfferings == null)
            {
                return HttpNotFound();
            }
            return View(fitnessOfferings);
        }

        // GET: FitnessOfferings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FitnessOfferings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupTraining")] FitnessOfferings fitnessOfferings)
        {
            if (ModelState.IsValid)
            {
                db.FitnessOfferings.Add(fitnessOfferings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fitnessOfferings);
        }

        // GET: FitnessOfferings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessOfferings fitnessOfferings = db.FitnessOfferings.Find(id);
            if (fitnessOfferings == null)
            {
                return HttpNotFound();
            }
            return View(fitnessOfferings);
        }

        // POST: FitnessOfferings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,GroupTraining")] FitnessOfferings fitnessOfferings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fitnessOfferings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fitnessOfferings);
        }

        // GET: FitnessOfferings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessOfferings fitnessOfferings = db.FitnessOfferings.Find(id);
            if (fitnessOfferings == null)
            {
                return HttpNotFound();
            }
            return View(fitnessOfferings);
        }

        // POST: FitnessOfferings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FitnessOfferings fitnessOfferings = db.FitnessOfferings.Find(id);
            db.FitnessOfferings.Remove(fitnessOfferings);
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
