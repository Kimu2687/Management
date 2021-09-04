using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attendant_check.Models
{

    public class Cartons
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Carton Category", Prompt = "Carton category")]
        public string Carton_category { get; set; }

        [Required]
        [Display(Name = "Buying price", Prompt = "Buying price")]
        public decimal Buying_price { get; set; }


        [Display(Name = "Selling price", Prompt = "Selling price")]
        public decimal Selling_price { get; set; } 


        [Required]
        [Display(Name = "No of bottle", Prompt = "No of bottle")]
        public int No_of_bottle { get; set; }

        [Required]
        [Display(Name = "No of bottle per carton", Prompt = "No of bottle per carton")]
        public int bottle_per_carton { get; set; }

        //[Required]
        //[Display(Name = "Role", Prompt = "Role")]
        //public string Roles { get; set; }


    

     






    }
}
