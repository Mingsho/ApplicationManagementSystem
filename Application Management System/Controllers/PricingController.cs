using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Application_Management_System.DAL;
using Application_Management_System.Models;

namespace Application_Management_System.Controllers
{
    public class PricingController : Controller
    {
        private AmsContext db = new AmsContext();

        // GET: Pricing
        public ActionResult Index()
        {
            var pricings = db.Pricings.Include(p => p.Course);
            return View(pricings.ToList());
        }

        // GET: Pricing/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pricing pricing = db.Pricings.Find(id);
            if (pricing == null)
            {
                return HttpNotFound();
            }
            return View(pricing);
        }

        // GET: Pricing/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "VetNationalCode");
            return View();
        }

        // POST: Pricing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PricingID,CourseID,CourseType,TuitionFee,MaterialFee,ApplicationFee,PricingComment")] Pricing pricing)
        {
            if (ModelState.IsValid)
            {
                db.Pricings.Add(pricing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "VetNationalCode", pricing.CourseID);
            return View(pricing);
        }

        // GET: Pricing/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pricing pricing = db.Pricings.Find(id);
            if (pricing == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "VetNationalCode", pricing.CourseID);
            return View(pricing);
        }

        // POST: Pricing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PricingID,CourseID,CourseType,TuitionFee,MaterialFee,ApplicationFee,PricingComment")] Pricing pricing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pricing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "VetNationalCode", pricing.CourseID);
            return View(pricing);
        }

        // GET: Pricing/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pricing pricing = db.Pricings.Find(id);
            if (pricing == null)
            {
                return HttpNotFound();
            }
            return View(pricing);
        }

        // POST: Pricing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pricing pricing = db.Pricings.Find(id);
            db.Pricings.Remove(pricing);
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
