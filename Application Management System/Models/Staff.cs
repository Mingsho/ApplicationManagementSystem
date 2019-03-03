using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application_Management_System.Models
{
    public class Staff
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffID { get; set; }

        [Required(ErrorMessage ="*This field is required!")]
        [StringLength(60,ErrorMessage ="*Field length exceeded!")]
        [Display(Name ="First Name:")]
        public string FirstMidName { get; set; }

        [Display(Name ="Last Name:")]
        public string LastName { get; set; }

        [Display(Name ="Staff Rep Name:")]
        public string FullName
        {
            get
            {
                return FirstMidName + " " + LastName;
            }
        }
    }
}