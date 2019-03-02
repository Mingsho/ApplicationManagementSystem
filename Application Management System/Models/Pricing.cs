using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application_Management_System.Models
{
    public enum CourseType
    {
        Onshore,Offshore
    }
    public class Pricing
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PricingID { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Display(Name ="Course Type")]
        public CourseType CourseType { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="Tuition Fee")]
        public double TuitionFee { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="Material Fee")]
        public double MaterialFee { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="Application Fee")]
        public double ApplicationFee { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name ="Pricing Comment")]
        public string PricingComment { get; set; }

        public virtual Course Course { get; set; }
    }
}