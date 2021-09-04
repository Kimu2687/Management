using Attendant_check.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpPost]
        public JsonResult  insert_employees(string Industry_employees, int Supply_employees, decimal Salary)
        {
            //LETS CHECK IF EMPLOYEES DETAILS ARE AVAILABLE 
            var CHECK_EMPL = _context.Employees.ToList();
            if (CHECK_EMPL.Count!= 0)
            {
                //LETS JUST UPDATE
                var TO_UPDATE = _context.Employees.FirstOrDefault();
                TO_UPDATE.Industry_employees = Industry_employees;
                TO_UPDATE.Supply_employees = Supply_employees;
                TO_UPDATE.Salary = Salary;
                _context.Entry(TO_UPDATE).State = EntityState.Modified;
                _context.SaveChanges();
                res.response_message = "Success, Record updatd successfully!";

                //swal("Success", "Salary details updated successfully", "success");
            }

            else
            {
                //LETS ADD NEW RECORDS(NO RECORDS FOUND)
                Employees x = new Employees();
                x.Industry_employees = Industry_employees;
                x.Supply_employees = Supply_employees;
                x.Salary = Salary;
                _context.Add(x);
                _context.SaveChanges();
                //swal("Success", "Salary details recorded successfully", "success");
                res.response_message = "Success, Record inserted successfully!";
            }
            return Json(res);
        }
        
        [HttpPost]
        public JsonResult add_bottles(string transport, int quantity, string category)
        {
            //LETS ADD BOTTLES TO THIS CATEGORY 
            var P_QUANTITY = _context.Cartons.FirstOrDefault(x => x.Carton_category == category);
            int p_QNTY = P_QUANTITY.No_of_bottle;
            int N_QNTY = p_QNTY + quantity;
            P_QUANTITY.No_of_bottle = N_QNTY;
            _context.Entry(P_QUANTITY).State = EntityState.Modified;
            _context.SaveChanges();


            ////LETS RECORD THE SALES
            //Cartons_sold C_S = new Cartons_sold();
            //C_S.Cartons_sold_ = quantity_five;
            //C_S.Carton_category = category;
            //C_S.Date = DateTime.Now.ToString("dd/MM/yyyy");
            //C_S.Total = P_QUANTITY.Selling_price * quantity_five;
            //_context.Add(C_S);
            //_context.SaveChanges();

            //LETS UPDATE THE DASHBOARD WITH THE NEW 

            //LETS UPDATE THE EXPENSE(TRANSPORT)
            Expenses EX = new Expenses();
            EX.Expense = "Transport";
            EX.Ammount = transport;
            EX.Date = DateTime.Now.ToString("dd/MM/yyyy");
            _context.Add(EX);
            _context.SaveChanges();


            //LETS UPDATE THE INTERFACE WITH THE NEW BOTTLE QUANTITY
            res.response_message = N_QNTY.ToString();

            return Json(res);
        }

        public IActionResult Dashboard()
        {
            //LETS BIND THE REQUIRED RECORDS
            ViewBag.cartons = _context.Cartons.ToList();
            ViewBag.one_litre = _context.Cartons.FirstOrDefault(x => x.Carton_category == "1 Litre").No_of_bottle;
            ViewBag.five_litre = _context.Cartons.FirstOrDefault(x => x.Carton_category == "5 Litres").No_of_bottle;

            var employees = _context.Employees.FirstOrDefault();

            ViewBag.industry_empl = employees.Industry_employees;
            ViewBag.supply_empl = employees.Supply_employees;
            ViewBag.salary = employees.Salary;

          
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
