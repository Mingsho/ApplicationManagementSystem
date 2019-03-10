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
using Application_Management_System.ViewModels;

namespace Application_Management_System.Controllers
{
    public class ApplicantController : Controller
    {
        private AmsContext db = new AmsContext();

        public ActionResult Index(int? Id)
        {
            var viewModel = new ApplicantIndexData
            {
                Applicants = db.Applicants
                .Include(a => a.Applications)
                .OrderBy(a => a.FirstMidName)
                
            };

            //if applicant is selected, populate
            //viewmodels courses i.e the courses enrolled
            //by the applicant
            if (Id != null)
            {
                ViewBag.ApplicantID = Id.Value;

                //all applications of the applicant.
                viewModel.Applications = viewModel.Applicants.Where(
                    a => a.ApplicantID == Id.Value).Single().Applications;

                viewModel.Course = viewModel.Applications.Where(
                    a => a.ApplicantID == Id.Value).Single().Course;
            }
            

            return View(viewModel);
        }

        // GET: Applicant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // GET: Applicant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applicant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicantID,SecondaryID,FirstMidName,LastName,DateOfBirth,Country,EmailAddress,ContactNumber")] Applicant applicant)
        {
            int applicantID = 0;
            if (ModelState.IsValid)
            {
                db.Applicants.Add(applicant);
                db.SaveChanges();

                applicantID = applicant.ApplicantID;

                //after the creation of the applicant,
                //user will be directed to process the application
                //for the applicant.
                return RedirectToAction("Create", "Application", new { Id = applicantID });

                //return RedirectToAction("Index");
            }

            return View(applicant);
        }

        private void PopulateCourseDropdown(object strSelectedCourse = null)
        {
            var coursesQuery = from c in db.Courses
                               orderby c.VetNationalCode
                               select c;

            ViewBag.CourseID = new SelectList(coursesQuery, "CourseID", "CodeCourseName", strSelectedCourse);
        }

        private void PopulateAgentDropdown(object strselectedAgent = null)
        {
            var agentQuery = from a in db.Agents
                             orderby a.LegalName
                             select a;

            ViewBag.AgentID = new SelectList(agentQuery, "AgentID", "TradingName", strselectedAgent);
        }

        // GET: Applicant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicantID,SecondaryID,FirstMidName,LastName,DateOfBirth,Country,EmailAddress,ContactNumber")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicant);
        }

        // GET: Applicant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            db.Applicants.Remove(applicant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      
        
    }

    
}
