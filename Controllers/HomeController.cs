﻿using Attendant_check.Models;
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
        public JsonResult add_bottles(decimal transport, int quantity, string category)
        {
            //LETS ADD BOTTLES TO THIS CATEGORY 
            var P_QUANTITY = _context.Cartons.FirstOrDefault(x => x.Carton_category == category);
            int p_QNTY = P_QUANTITY.No_of_bottle;
            int N_QNTY = p_QNTY + quantity;
            P_QUANTITY.No_of_bottle = N_QNTY;
            _context.Entry(P_QUANTITY).State = EntityState.Modified;
            _context.SaveChanges();


          

         

            //LETS UPDATE THE EXPENSE(TRANSPORT)
            Expenses EX = new Expenses();
            EX.Expense = "Transport";
            EX.Ammount = transport;
            EX.Date = DateTime.Now;
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

            var one_litre = _context.Cartons.FirstOrDefault(x => x.Carton_category == "1 Litre");
            var five_litres = _context.Cartons.FirstOrDefault(x => x.Carton_category == "5 Litres");
            var employees = _context.Employees.FirstOrDefault();

            if (one_litre != null)
            {
                ViewBag.one_litre = one_litre.No_of_bottle;

            }
            else
            {
                ViewBag.one_litre = 0;

            }
            if (five_litres != null)
            {
                ViewBag.five_litre = five_litres.No_of_bottle;

            }
            else
            {
                ViewBag.five_litre = 0;

            }
            if (employees != null)
            {


                ViewBag.industry_empl = employees.Industry_employees;
                ViewBag.supply_empl = employees.Supply_employees;
                ViewBag.salary = employees.Salary;
            }
            else
            {
          
                ViewBag.industry_empl = 0;
                ViewBag.supply_empl = 0;
                ViewBag.salary = 0;
            }


            
           
           
          
            return View();
        }public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult sell_item(string carton_,int carton_sold)
        {
            //LETS KEEP THE RECORDS OF THE SALES
            var GET_FIELDS = _context.Cartons.FirstOrDefault(X => X.Carton_category == carton_);

            //LETS CHECK IF REMAINIG STOCK IS NEGATIVE

            int BOTTLES_IN_STOCK = GET_FIELDS.No_of_bottle;
            int NEW_STOCK = BOTTLES_IN_STOCK - carton_sold;
            //--------------------------------------------------------------------------------------------------------------------------------------------
            if (NEW_STOCK < 0)
            {
                swal("Qntyt Sold: "+carton_sold,  "You have entered an invalid quantity", "error");
            }
            else
            {
                //NOW LETS PDATE THE REMAINING BOTTLES BY SUBTRACTING SOLD BOTTLES FROM INITIAL STOCK
                Cartons_sold C_S = new Cartons_sold();
                C_S.Cartons_sold_ = carton_sold;
                C_S.Carton_category = carton_;
                C_S.Date = DateTime.Now;
                C_S.Total = GET_FIELDS.Selling_price * carton_sold;
                _context.Add(C_S);
                _context.SaveChanges();



                //LETS GET NUMBER OF BOTTLES SOLD BY CONVERTING CARTONS TO BOTTLES
                decimal PRICE_PER_CARTON = GET_FIELDS.Selling_price;
                int BOTTLES_PER_CARTON = GET_FIELDS.bottle_per_carton;
                int SOLD_BOTTLES = carton_sold / BOTTLES_PER_CARTON;



                //LETS UPDATE
                GET_FIELDS.No_of_bottle = NEW_STOCK;
                _context.Entry(GET_FIELDS).State = EntityState.Modified;
                _context.SaveChanges();
                swal("Success!", carton_sold + " Cartons of " + carton_ + " has been sold. New stock is: " + NEW_STOCK, "success");

            }
            return Redirect("~/Home/Dashboard");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
