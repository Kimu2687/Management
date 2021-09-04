using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TASK.Base_controller
{
    public abstract class BaseController : Controller
    {
        
        protected virtual void swal(string header, string msg, string msg_type)
        {
            TempData["msg_header"] = header;
            TempData["msg"] = msg;
            TempData["msg_type"] = msg_type;

      
        }

        //GLOBAL AJAX RESPONSE
        public class Total_cash_made
        { 
            public string response_message { get; set; }
        }

        //FEEDING THE MESSAGE
        public Total_cash_made res = new Total_cash_made();
    }
  
}