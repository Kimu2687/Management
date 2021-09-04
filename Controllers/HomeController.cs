using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TASK.Base_controller;
using TASK.Models;

namespace TASK.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Database_Context _context;

        public HomeController(ILogger<HomeController> logger, Database_Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Close_month()
        {
            return View();
        }public IActionResult Index()
        {
            return View();
        }public IActionResult Reports()
        {
            return View();
        }
        
        public IActionResult log_in()
        {

            return View();
        }

        public IActionResult Dashboard()
        {
            //LETS BIND THE REQUIRED RECORDS
            ViewBag.cartons = _context.Cartons.ToList();
            ViewBag.one_litre = _context.Cartons.FirstOrDefault(x => x.Carton_category == "1 Litre").No_of_bottle;
            ViewBag.five_litre = _context.Cartons.FirstOrDefault(x => x.Carton_category == "5 Litres").No_of_bottle;
         
            ViewBag.count_items = 1;
            return View();
        }public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
