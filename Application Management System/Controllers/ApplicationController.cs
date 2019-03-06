using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application_Management_System.Models;
using Application_Management_System.DAL;

namespace Application_Management_System.Controllers
{
    public class ApplicationController: Controller
    {
        private AmsContext db = new AmsContext();

        public ViewResult Index()
        {
            return View(db.Applications.ToList());
        }

         
    }
}