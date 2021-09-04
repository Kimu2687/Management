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

            // Do stuff
        }
    }
}