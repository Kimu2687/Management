using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attendant_check.Models
{

    public class Employees
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "No. of Industry employees", Prompt = "Industry employees")]
        public int Industry_employees { get; set; }

        [Required]
        [Display(Name = "No. of Supply employees", Prompt = "Supply employees")]

        public int Supply_employees { get; set; }


        [Display(Name = "Salary", Prompt = "Salary")]
        public decimal Salary { get; set; } 



    

     






    }
}
