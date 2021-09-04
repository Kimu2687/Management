using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attendant_check.Models
{

    public class Cartons_sold
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Carton category", Prompt = "Carton category")]
        public string Carton_category { get; set; }

        [Required]
        [Display(Name = "Cartons sold", Prompt = "Cartons sold")]
        public int Cartons_sold_ { get; set; }

        [Required]
        [Display(Name = "Total", Prompt = "Total")]
        public decimal Total { get; set; }

        [Required]
        [Display(Name = "Date", Prompt = "Date")]
        public string Date { get; set; }
        

    }
}
