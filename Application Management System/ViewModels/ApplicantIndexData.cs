using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application_Management_System.Models;

namespace Application_Management_System.ViewModels
{
    public class ApplicantIndexData
    {
        public IEnumerable<Applicant> Applicants { get; set; }
        public IEnumerable<Application> Applications { get; set; }
        public Course Course { get; set; }
    }
}