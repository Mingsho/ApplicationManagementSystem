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
    public class StaffController: Controller
    {
        private AmsContext db = new AmsContext();

        //public ActionResult Index()
        //{
        //    return View(db.Staffs.ToList());
        //}

        public ViewResult Index(string sortOrder, string currentFilter,string searchString, int? page)
        {
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.IdSortParam = sortOrder == "staffID" ? "id_desc" : "staffID";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var staffRep = from s in db.Staffs
                           select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                staffRep = staffRep.Where(s => s.FirstMidName.Contains(searchString)
                  || s.LastName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    staffRep = staffRep.OrderByDescending(s => s.FirstMidName);
                    break;
                case "staffID":
                    staffRep = staffRep.OrderByDescending(s => s.StaffID);
                    break;
                case "id_desc":
                    staffRep = staffRep.OrderBy(s => s.StaffID);
                    break;
                default:
                    staffRep = staffRep.OrderBy(s => s.FirstMidName);
                    break;

            }

            int pageSize = 3;
            int pageNumber = page ?? 1;

            return View(staffRep.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(Id);

            if (staff == null)
            {
                return HttpNotFound();
            }

            return View(staff);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="StaffID,FirstMidname,LastName")]Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staffs.Add(staff);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(staff);
        }

        //GET
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(Id);

            if (staff == null)
            {
                return HttpNotFound();
            }

            return View(staff);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffID,FirstMidName,LastName")]Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(staff);
        }

        //GET
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Staff staff = db.Staffs.Find(Id);

            if (staff == null)
            {
                return HttpNotFound();
            }

            return View(staff);
        }

        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int Id)
        {
            Staff staff = db.Staffs.Find(Id);
            db.Staffs.Remove(staff);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}