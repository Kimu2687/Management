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
        public class general_class
        { 
            public string response_message { get; set; }
            public string Date_(string date)
            {
                String sDate = DateTime.Now.ToString(date);
                DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
                string DAY = datevalue.Day.ToString();
                return DAY;
            }//SPLIT YEAR
            public string Year(string date)
            {
                String sDate = DateTime.Now.ToString(date);
                DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
                string YEAR = datevalue.Year.ToString();
                return YEAR;
            }//SPLIT DAY
            public string Month(string date)
            {
                String sDate = DateTime.Now.ToString(date);
                DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
                string MNTH = datevalue.Month.ToString();
                return MNTH;
            }
        }


        //SPLIT DAY
       
        //FEEDING THE MESSAGE
        public general_class res = new general_class();

    }

}