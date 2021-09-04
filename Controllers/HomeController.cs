using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TASK.Models;

namespace TASK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
