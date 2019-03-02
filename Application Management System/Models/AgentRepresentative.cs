using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application_Management_System.Models
{
    public class AgentRepresentative
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgentRepresentativeID { get; set; }

        [Required(ErrorMessage ="*This field is required!")]
        [StringLength(60,ErrorMessage ="*Field length exceeded!")]
        [Display(Name ="First Name")]
        public string FirstMidName { get; set; }

        [StringLength(60,ErrorMessage ="*Field length exceeded!")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [StringLength(20,ErrorMessage ="*Field length exceeded!")]
        [Display(Name ="Contact Number")]
        public string ContactNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }

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