using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attendant_check.Models
{

    public class System_Users
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Full name", Prompt = "Full names")]
        public string Full_names { get; set; }

        [Required]
        [Display(Name = "Reg no", Prompt = "Reg no")]
        public string Staff_no { get; set; }


        [Display(Name = "Password", Prompt = "Password")]
        public string Password { get; set; } = "12345678";


        //[Required]
        //[Display(Name = "Date", Prompt = "Date")]
        //public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Role", Prompt = "Role")]
        public string Roles { get; set; }


    

     






    }
}
