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

         
    }
}