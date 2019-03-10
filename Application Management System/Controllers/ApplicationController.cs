using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using Application_Management_System.Models;
using Application_Management_System.DAL;
using Application_Management_System.ViewModels;

namespace Application_Management_System.Controllers
{
    public class ApplicationController: Controller
    {
        private AmsContext db = new AmsContext();

        public ViewResult Index()
        {
            IEnumerable<Application> app = db.Applications
                .Include(a => a.Applicant)
                .Include(a => a.Course)
                .OrderBy(a => a.ApplicationID);

            return View(app);
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var application = db.Applications.Find(Id);

            if (application == null)
            {
                return HttpNotFound();
            }

            return View(application);
        }

        //GET
        public ActionResult Create(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Application application = new Application();
            application.ApplicantID = Id.Value;


            PopulateCourseDropDown();

            PopulateAgentDropDown();

            return View(application);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="ApplicationID,ApplicantID,CourseID,ProposedStartDate,ProposedEndDate,LooIssuedDate,LooExpiryDate,AirportPickup,Accomodation,Oshc,AgentID" +
            "ApplicationStatus,MarketingComment,DepositReceived,DepositReceivedDate,TuitionFeeReceived,MaterialFeeReceived,ApplicationFeeReceived,OshcFeeReceived,OutstandingAmount" +
            "FinanceComments,ApplicationForm,ApplicationFormReceivedDate,PreTrainingReview,PtrCompletedDate,AcceptanceOfOffer,AcceptanceOfOfferDate,AcademicTranscripts,Passport" +
            "IeltsOrEquivalent,OshcCurrency,FiancialViability,CourseOutline,GteReviewed,AdministrationComment,PreEnrolmentInformation,EnrolledInSms,eCoeIssued,eCoeIssuedDate," +
            "DepositMatchingLoo,DatesMatchingLoo,CoeStatus,eCoeLastUpdated,RefundRequired,RefundAmount,DateRefundProcessed,CoeComment")]Application application)
        {
            if (ModelState.IsValid)
            {
                db.Applications.Add(application);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            PopulateCourseDropDown();
            PopulateAgentDropDown();

            return View(application);
        }

        private void PopulateCourseDropDown(object strCourseSelected=null)
        {
            var courseQuery = from c in db.Courses
                              orderby c.VetNationalCode
                              select c;
            ViewBag.CourseID = new SelectList(courseQuery, "CourseID", "CourseName", strCourseSelected);
        }

        private void PopulateAgentDropDown(object strAgentSelected = null)
        {
            var agentQuery = from a in db.Agents
                             orderby a.TradingName
                             select a;

            ViewBag.AgentID = new SelectList(agentQuery, "AgentID", "TradingName", strAgentSelected);

        }
        

         
    }
}