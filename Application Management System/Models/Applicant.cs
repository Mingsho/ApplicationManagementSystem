using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Application_Management_System.Models
{
    
    public class Applicant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicantID { get; set; }

        [Required(ErrorMessage ="*This field is required!")]
        [Display(Name ="Secondary ID")]
        public int? SecondaryID { get; set; }

        [Required(ErrorMessage ="*This field is required!")]
        [Display(Name ="First Name")]
        public string FirstMidName { get; set; }

        [Display(Name ="Middle Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage ="*This field is required!")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage ="*This field is required!")]
        public string Country { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name ="Contact Number")]
        public string ContactNumber { get; set; }

        [Display(Name ="Full Name")]
        public string FullName
        {
            get
            {
                return FirstMidName + " " + LastName;
            }
        }

    }
}