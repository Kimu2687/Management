using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attendant_check.Models
{

    public class Expenses

    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Expense", Prompt = "Expense")]
        public string Expense { get; set; }

        [Required]
        [Display(Name = "Ammount", Prompt = "Ammount")]
        public decimal Ammount { get; set; }


        [Display(Name = "Date", Prompt = "Date")]
        public DateTime Date { get; set; }
        
        


    

     






    }
}
