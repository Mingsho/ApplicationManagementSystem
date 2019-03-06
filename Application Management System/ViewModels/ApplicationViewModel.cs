using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application_Management_System.Models;

namespace Application_Management_System.ViewModels
{
    public class ApplicationViewModel
    {
        public Applicant Applicant { get; set; }
        public Application Application { get; set; }
    }
}