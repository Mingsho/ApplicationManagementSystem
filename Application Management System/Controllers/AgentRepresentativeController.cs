using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using Application_Management_System.DAL;
using Application_Management_System.Models;


namespace Application_Management_System.Controllers
{
    public class AgentRepresentativeController: Controller
    {
        private AmsContext db = new AmsContext();

        public ActionResult Index()
        {
            return View(db.AgentRepresentatives.ToList());
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgentRepresentative agentRepresentative = db.AgentRepresentatives.Find(Id);
            if (agentRepresentative == null)
            {
                return HttpNotFound();
            }
            return View(agentRepresentative);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="FirstMidName,LastName,ContactNumber,EmailAddress,FullName")]AgentRepresentative agentRepresentative)
        {
            if (ModelState.IsValid)
            {
                db.AgentRepresentatives.Add(agentRepresentative);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(agentRepresentative);
        }

        //GET
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgentRepresentative agentRepresentative = db.AgentRepresentatives.Find(Id);
            if (agentRepresentative == null)
            {
                return HttpNotFound();
            }
            return View(agentRepresentative);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="AgentRepresentativeID,FirstMidName,LastName,ContactNumber,EmailAddress")]AgentRepresentative agentRepresentative)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agentRepresentative).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agentRepresentative);
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AgentRepresentative
        }
    }
}