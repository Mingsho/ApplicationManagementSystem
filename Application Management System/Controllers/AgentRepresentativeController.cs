﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using PagedList;
using Application_Management_System.DAL;
using Application_Management_System.Models;


namespace Application_Management_System.Controllers
{
    public class AgentRepresentativeController: Controller
    {
        private AmsContext db = new AmsContext();

        //Index with sorting, searching and paging
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.IdSortParam = sortOrder == "agentRepID" ? "id_desc" : "agentRepID";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var agentRep = from a in db.AgentRepresentatives
                           select a;

            if (!string.IsNullOrEmpty(searchString))
            {
                agentRep = agentRep.Where(a => a.FirstMidName.Contains(searchString)
                || a.LastName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    agentRep = agentRep.OrderByDescending(a => a.FirstMidName);
                    break;

                case "agentRepID":
                    agentRep = agentRep.OrderBy(a => a.AgentRepresentativeID);
                    break;

                case "id_desc":
                    agentRep = agentRep.OrderByDescending(a => a.AgentRepresentativeID);
                    break;

                default:
                    agentRep = agentRep.OrderBy(a => a.FirstMidName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = page ?? 1;

            return View(agentRep.ToPagedList(pageNumber, pageSize));

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

        //GET
        public ActionResult Delete(int? Id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int Id)
        {
            
            AgentRepresentative agentRepresentative = db.AgentRepresentatives.Find(Id);
            db.AgentRepresentatives.Remove(agentRepresentative);
            db.SaveChanges();

            return RedirectToAction("Index");
            
        }
    }
}