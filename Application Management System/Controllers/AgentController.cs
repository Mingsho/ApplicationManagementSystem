using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using PagedList;
using Application_Management_System.Models;
using Application_Management_System.DAL;

namespace Application_Management_System.Controllers
{
    public class AgentController: Controller
    {
        private AmsContext db = new AmsContext();

        //Index with sorting, paging and searching
        public ViewResult Index(string sortOrder,string currentFilter,string searchString,int? page)
        {
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.Name1SortParam = string.IsNullOrEmpty(sortOrder) ? "name1_desc" : "";
            ViewBag.Name2SortParam = string.IsNullOrEmpty(sortOrder) ? "name2_desc" : "name2_asc";
            ViewBag.IdSortParam = sortOrder == "id_asc" ? "id_desc" : "id_asc";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var agent = from a in db.Agents
                        select a;

            if (!string.IsNullOrEmpty(searchString))
            {
                agent = agent.Where(a => a.LegalName.Contains(searchString)
                  || a.TradingName.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "name1_desc":
                    agent = agent.OrderByDescending(a => a.LegalName);
                    break;
                case "name2_desc":
                    agent = agent.OrderByDescending(a => a.ContactPerson);
                    break;
                case "name2_asc":
                    agent = agent.OrderBy(a => a.ContactPerson);
                    break;
                case "id_desc":
                    agent = agent.OrderByDescending(a => a.AgentID);
                    break;
                case "id_asc":
                    agent = agent.OrderBy(a => a.AgentID);
                    break;
                case "date_desc":
                    agent = agent.OrderByDescending(a => a.AgreementSignedDate);
                    break;
                case "Date":
                    agent = agent.OrderBy(a => a.AgreementSignedDate);
                    break;
                default:
                    agent = agent.OrderBy(a => a.LegalName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = page ?? 1;

            return View(agent.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agent = (from a in db.Agents.Include(a => a.AgentRepresentative).Include(a => a.Staff)
                         where a.AgentID == Id
                         select a).Single();

            if (agent == null)
            {
                return HttpNotFound();
            }

            return View(agent);

        }

        //GET
        public ActionResult Create()
        {
            PopulateAgentRepresentativeDropDown();
            PopulateStaffDropDown();
            return View();
            
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="AgentID,LegalName,TradingName,EmailAddress,ContactNumber,ContactPerson," +
            "AgentApplicationForm,CompanyRegistration,Agreement,AgreementSignedDate,CompanyProfile,ReportedToAsqa,AgentRepresentativeID,StaffID")]Agent agent)
        {
            if (ModelState.IsValid)
            {
                db.Agents.Add(agent);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            PopulateAgentRepresentativeDropDown();
            PopulateStaffDropDown();
            return View(agent);
        }

        //GET
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(Id);
            if (agent == null)
            {
                return HttpNotFound();
            }

            PopulateAgentRepresentativeDropDown(agent.AgentRepresentativeID);
            PopulateStaffDropDown(agent.StaffID);
            return View(agent);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="AgentID,LegalName,TradingName,EmailAddress,ContactNumber," +
            "ContactPerson,AgentApplicationForm,CompanyRegistration,Agreement,AgreementSignedDate,CompanyProfile," +
            "ReportedToAsqa,AgentRepresentativeID,StaffID")]Agent agent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agent).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(agent);
        }

        private void PopulateAgentRepresentativeDropDown(object strSelected=null)
        {
            var agentRep = from a in db.AgentRepresentatives
                           orderby a.FirstMidName
                           select a;
            ViewBag.AgentRepresentativeID = new SelectList(agentRep, "AgentRepresentativeID", "FullName", strSelected);
        }

        private void PopulateStaffDropDown(object strSelected = null)
        {
            var staff = from s in db.Staffs
                        orderby s.FirstMidName
                        select s;
            ViewBag.StaffID = new SelectList(staff, "StaffID", "FullName", strSelected);
        }

        //GET
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(Id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int Id)
        {
            Agent agent = db.Agents.Find(Id);
            db.Agents.Remove(agent);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}