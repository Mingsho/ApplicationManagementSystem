using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application_Management_System.Models;
using Application_Management_System.ViewModels;

namespace Application_Management_System.Utilities
{
    public class ApplicationModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            ApplicationViewModel appViewModel = new ApplicationViewModel();

           

            appViewModel.Applicant.SecondaryID = int.Parse(request.Form.Get("SecondaryID"));
            appViewModel.Applicant.FirstMidName = request.Form.Get("FirstMidName");
            appViewModel.Applicant.LastName = request.Form.Get("LastName");
            appViewModel.Applicant.DateOfBirth = DateTime.Parse(request.Form.Get("DateOfBirth"));
            appViewModel.Applicant.Country = request.Form.Get("Country");
            appViewModel.Applicant.ContactNumber = request.Form.Get("ContactNumber");

            appViewModel.Application.CourseID = int.Parse(request.Form.Get("CourseID"));
            appViewModel.Application.ProposedStartDate = DateTime.Parse(request.Form.Get("ProposedStartDate"));
            appViewModel.Application.ProposedEndDate = DateTime.Parse(request.Form.Get("ProposedEndDate"));
            appViewModel.Application.LooIssuedDate = DateTime.Parse(request.Form.Get("LooIssuedDate"));
            appViewModel.Application.LooExpiryDate = DateTime.Parse(request.Form.Get("LooExpiryDate"));
            appViewModel.Application.AirportPickup = bool.Parse(request.Form.Get("AirportPickup"));
            appViewModel.Application.Accomodation = bool.Parse(request.Form.Get("Accomodation"));
            appViewModel.Application.Oshc = bool.Parse(request.Form.Get("Oshc"));
            appViewModel.Application.AgentID = int.Parse(request.Form.Get("AgentID"));
            //appViewModel.Application.ApplicationStatus = Enum.Parse(typeof(ApplicationStatus), request.Form.Get("ApplicationStatus"));





        }
    }
}