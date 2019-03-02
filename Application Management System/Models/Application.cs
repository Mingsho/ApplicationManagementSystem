using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application_Management_System.Models;

namespace Application_Management_System.Models
{
    public enum ApplicationStatus
    {
        Processed,Pending,Rejected,Expired
    }
    public enum CoeStatus
    {
        Approved,Visa_Granted,Visa_Refused,Expired
    }
    public class Application
    {

        #region Course Details

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationID { get; set; }

        [Required]
        [Display(Name ="Applicant ID:")]
        public int ApplicantID { get; set; }

        [Required]
        [Display(Name ="Course ID:")]
        public int CourseID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Proposed Course Start Date:")]
        public DateTime ProposedStartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Proposed Course End Date:")]
        public DateTime ProposedEndDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Letter of Offer Issue Date:")]
        public DateTime LooIssuedDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Letter of Offer Expiry Date:")]
        public DateTime LooExpiryDate { get; set; }

        [Display(Name ="Aiport Pickup Required?:")]
        public bool AirportPickup { get; set; }

        [Display(Name ="Accomodation Required?:")]
        public bool Accomodation { get; set; }

        [Display(Name ="Provider to book OSHC?:")]
        public bool Oshc { get; set; }

        public int AgentID { get; set; }

        public ApplicationStatus ApplicationStatus { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name ="Marketing Comments:")]
        public string MarketingComment { get; set; }

        #endregion

        #region FinancialDetails

        [Display(Name ="Deposit Received?:")]
        public bool DepositReceived { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Deposit Received Date:")]
        public DateTime? DepositReceivedDate { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="Tuition Fee:")]
        public double TuitionFeeReceived { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="Material Fee:")]
        public double MaterialFeeReceived { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="Application Fee:")]
        public double ApplicationFeeReceived { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="OSHC Fee:")]
        public double OshcFeeReceived { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="Outstanding Amount:")]
        public double OutstandingAmount { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name ="Finance Comment:")]
        public string FinanceComments { get; set; }
        #endregion

        #region DocumentChecklist

        [Display(Name ="Application Form Received?:")]
        public bool ApplicationForm { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Application Form Received Date:")]
        public DateTime ApplicationFormReceivedDate { get; set; }

        [Display(Name ="Pre-Training Review completed?:")]
        public bool PreTrainingReview { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Pre-Training Review Completed Date:")]
        public DateTime? PtrCompletedDate { get; set; }

        [Display(Name ="Acceptance of Offer:")]
        public bool AcceptanceOfOffer { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Acceptance of Offer Signed Date:")]
        public DateTime? AcceptanceOfOfferDate { get; set; }

        [Display(Name ="Academic Transcript Verified?:")]
        public bool AcademicTranscripts { get; set; }

        [Display(Name ="Passport Verified?:")]
        public bool Passport { get; set; }

        [Display(Name ="IELTS or Equivalent Verified?:")]
        public bool IeltsOrEquivalent { get; set; }

        [Display(Name ="OSHC Currency & Certificate Verified?:")]
        public bool OshcCurrency { get; set; }

        [Display(Name ="Financial Viability Verified?:")]
        public bool FinancialViability { get; set; }

        [Display(Name ="Course Outline Sent?:")]
        public bool CourseOutline { get; set; }

        [Display(Name ="GTE Document Reviewed?:")]
        public bool GteReviewed { get; set; }

        [Display(Name ="Administration Comment:")]
        public string AdministrationComment { get; set; }

        [Display(Name ="Pre-Enrolment Information Sent?:")]
        public bool PreEnrolmentInformation { get; set; }

        [Display(Name ="Enroled in SMS?:")]
        public bool EnrolledInSms { get; set; }
        #endregion

        #region CoeDetails

        [Display(Name ="eCOE Issued?:")]
        public bool eCoeIssued { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="eCOE Issued Date:")]
        public DateTime? eCoeIssuedDate { get; set; }

        [Display(Name ="Deposit Matching LOO?:")]
        public bool DepositMatchingLoo { get; set; }

        [Display(Name ="Dates Matching LOO?:")]
        public bool DatesMatchingLoo { get; set; }

        [Display(Name ="eCOE Status:")]
        public CoeStatus CoeStatus { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="eCOE Last Updated Date:")]
        public DateTime? eCoeLastUpdated { get; set; }

        [Display(Name ="Refund Required?:")]
        public bool RefundRequired { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="Refunded Amount:")]
        public double RefundAmount { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Date Refund Processed:")]
        public DateTime? DateRefundProcessed { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name ="COE Comment:")]
        public string CoeComment { get; set; }
        #endregion


        public virtual ICollection<Applicant> Applicant { get; set; }

        public virtual ICollection<Course> Course { get; set; }




    }
}