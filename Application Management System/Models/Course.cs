using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application_Management_System.Models
{
    public class Course
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }

        [Required(ErrorMessage ="*This field is required!")]
        public string VetNationalCode { get; set; }

        [Required(ErrorMessage ="*This field is required!")]
        [MaxLength(125,ErrorMessage ="*Max Length for the name exceeded!")]
        public string CourseName { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(250)]
        public string CourseComment { get; set; }

        [Display(Name ="Code-Course Name")]
        public string CodeCourseName
        {
            get
            {
                return VetNationalCode + " " + CourseName;
            }
        }

        public virtual ICollection<Pricing> Pricing { get; set; }
    }
}