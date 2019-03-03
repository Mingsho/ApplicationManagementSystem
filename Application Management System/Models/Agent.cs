using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application_Management_System.Models
{
    public class Agent
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Agent ID:")]
        public int AgentID { get; set; }

        [StringLength(120,ErrorMessage ="*Field length exceeded!")]
        [Display(Name ="Legal Name:")]
        public string LegalName { get; set; }

        [Required(ErrorMessage ="*This field is required!")]
        [Display(Name ="Trading Name:")]
        public string TradingName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email Address:")]
        public string EmailAddress { get; set; }

        [Display(Name ="Contact Number:")]
        [StringLength(20,ErrorMessage ="*Field length exceeded!")]
        public string ContactNumber { get; set; }

        [Display(Name ="Contact Person:")]
        [StringLength(60,ErrorMessage ="*Field length exceeded!")]
        public string ContactPerson { get; set; }

        [Display(Name ="Agent Application Form:")]
        public bool AgentApplicationForm { get; set; }

        [Display(Name ="Company Registration:")]
        public bool CompanyRegistration { get; set; }

        [Display(Name ="Signed Agreement:")]
        public bool Agreement { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Agreement Signed Date:")]
        public DateTime? AgreementSignedDate { get; set; }

        [Display(Name ="Company Profile:")]
        public bool CompanyProfile { get; set; }

        [Display(Name ="Reported to Asqa:")]
        public bool ReportedToAsqa { get; set; }

        
        public int AgentRepresentativeID { get; set; }

        public int StaffID { get; set; }

        public virtual AgentRepresentative AgentRepresentative { get; set; }
        public virtual Staff Staff { get; set; }

    }
}