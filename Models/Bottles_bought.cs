using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attendant_check.Models
{

    public class Bottles_bought
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "No. of Bottles", Prompt = "No. of bottles")]
        public string Carton_category { get; set; }

        [Required]
        [Display(Name = "Price", Prompt = "Price")]
        public int Price { get; set; }

        [Required]
        [Display(Name = "Total", Prompt = "Total")]
        public decimal Total { get; set; } 
        
        [Required]
     
        public int Initial_stock { get; set; }
        public int Final_stock { get; set; }

        [Required]
        [Display(Name = "Date", Prompt = "Date")]
        public string Date { get; set; }
        

    }
}
