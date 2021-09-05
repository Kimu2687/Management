using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attendant_check.Models
{

    public class Monthly_sales

    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Electricity bill", Prompt = "Electricity bill")]
        public decimal Electricity_bill { get; set; }

        [Required]
        [Display(Name = "Water bill", Prompt = "Wtery bill")]

        public decimal water_bill { get; set; }
        [Required]
        [Display(Name = "Revenue", Prompt = "Revenue")]
        public decimal Revenue { get; set; }


        [Display(Name = "Transport", Prompt = "Transport")]
        public decimal Transport { get; set; } 


        [Required]
        [Display(Name = "Salary", Prompt = "Salary")]
        public decimal Salary { get; set; }

        [Required]
        [Display(Name = "Buying expenses", Prompt = "Buying expenses")]
        public decimal Buying_expenses { get; set; }
        
        [Required]
        [Display(Name = "Cash collected", Prompt = "Cash collected")]
        public decimal Gross_income { get; set; }   
       
        public decimal Profit { get; set; }   
        
        [Required]
        [Display(Name = "Date", Prompt = "Date")]
        public DateTime Date { get; set; }

      

    

     






    }
}
