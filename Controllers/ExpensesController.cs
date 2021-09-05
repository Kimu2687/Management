using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Attendant_check.Models;
using TASK;
using static TASK.Base_controller.BaseController;
using TASK.Base_controller;
using System.Runtime.InteropServices;

namespace Attendant_check.Controllers
{
    public class ExpensesController : BaseController
    {

        private readonly Database_Context _context;
        private static string sDate = DateTime.Now.ToString();
        private static  DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
        String DAY = datevalue.Day.ToString();
        String MM = datevalue.Month.ToString();
        String YY = datevalue.Year.ToString();
        

        public ExpensesController(Database_Context context)
        {
            _context = context;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Expenses.ToListAsync());
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenses = await _context.Expenses
                .FirstOrDefaultAsync(m => m.id == id);
            if (expenses == null)
            {
                return NotFound();
            }

            return View(expenses);
        }

        // GET: Expenses/Create
        public IActionResult Create([Optional] string submit)
        {

          

            //INSTANSTIATING GENERAL CLASS FROM BASE CONTROLLER

            general_class x = new general_class();
            string Month = x.Month(DateTime.Now.ToString("MM/dd/yyyy"));
            //LETS CHECK IF WE SUBMITTED MONTHLY SALES
            var CHECK_MONTHLY = _context.Monthly_sales.FirstOrDefault(x => x.Date.Month.ToString() == Month);
            if (CHECK_MONTHLY != null)
            {
                //LETS HIDE SUBMIT BUTTON FROM THE INTERFACE
                ViewBag.hide_submit_m = 1;
            }
            //LETS CALCULATE TRANSPORT THIS MONTH
            var CHECK_TRANSPORT = _context.Expenses.Where(j => j.Expense == "Transport" && j.Date.Month.ToString()==Month).Sum(c=>c.Ammount);
            if (CHECK_TRANSPORT != null)
            {
                ViewBag.transport = CHECK_TRANSPORT;
                ViewBag.hide_button = "1";

            }
            else
            {
                ViewBag.transport = 0;
                //ViewBag.hide_button = "1";
            }
            //LETS FIND CARTONS SOLD THIS MONTH
            double SOLD_CARTONS_THIS_MONTH = _context.Cartons_sold.Where(x => x.Date.Month.ToString() == Month).Sum(b => b.Cartons_sold_);
            ViewBag.sold_cartons = SOLD_CARTONS_THIS_MONTH;

            //LETS CALCULATE THE REVENUE
            double REVENUE = 0.05 * (SOLD_CARTONS_THIS_MONTH * 300);
            ViewBag.total_rvenue = REVENUE;
            //LETS POPULATE CASH MADE
            ViewBag.Cash_made = SOLD_CARTONS_THIS_MONTH * 300;

            //LETS GET WATER & WATER BILLS
            var WATER_BILL = _context.Expenses.Where(j => j.Expense == "Water" && j.Date.Month.ToString() == Month).Sum(c => c.Ammount);
            ViewBag.water_bill = WATER_BILL;

            //LETS GET ELECTRICITY BILLS 
            var ELECTRICITY_BILL = _context.Expenses.Where(j => j.Expense == "Electricity" && j.Date.Month.ToString() == Month).Sum(c => c.Ammount);
            ViewBag.electricity_bill = ELECTRICITY_BILL;


            //LETS GET SALARY DETAILS
            var GET_SAL = _context.Employees.FirstOrDefault();
            int ALL_EMPLOYEES = GET_SAL.Industry_employees + GET_SAL.Supply_employees;
            decimal SALARY = GET_SAL.Salary;
            decimal TOTAL = ALL_EMPLOYEES * SALARY;
            ViewBag.total_salary = TOTAL;
            ViewBag.salary = SALARY;
            ViewBag.industry_empl = GET_SAL.Industry_employees;
            ViewBag.supply_empl = GET_SAL.Supply_employees;


            //EXPENSES INCURED IN BUYING BOTLES
            // 1 Litre BOTTLE
            decimal  ONE_LITRE = _context.Expenses.Where(n => n.Expense == "Buying_1 Litre" && n.Date.Month.ToString() == Month).Sum(b => b.Ammount);
            ViewBag.one_litre = ONE_LITRE; 
            decimal  FIVE_LITRE = _context.Expenses.Where(n => n.Expense == "Buying_5 Litres" && n.Date.Month.ToString() == Month).Sum(b => b.Ammount);
            ViewBag.five_litre = FIVE_LITRE;

            decimal SUM_OF_BUYING_EX = ONE_LITRE + FIVE_LITRE;
            ViewBag.buying_expense = SUM_OF_BUYING_EX;



            //SUM OF ALL DEDUCTIONS

            double TOTAL_D = Decimal.ToDouble(TOTAL) +Decimal.ToDouble(WATER_BILL) + Decimal.ToDouble(ELECTRICITY_BILL)+ REVENUE +Decimal.ToDouble(CHECK_TRANSPORT)+ Decimal.ToDouble(SUM_OF_BUYING_EX);
            ViewBag.Total_deduction = TOTAL_D;

            //LETS CALCULATE PROFIT
            //.....CASH COLLECTED THIS MONTH
            double SALES_CASH = (SOLD_CARTONS_THIS_MONTH * 300);

            //.....PROFIT
            double PROFIT = SALES_CASH - TOTAL_D;
            ViewBag.profit = PROFIT;

            //LETS RECORD SALES RECORDS FOR THIS MONTH
            if (submit != null)
            {


                Monthly_sales M_SALES_CASH = new Monthly_sales();
                M_SALES_CASH.Buying_expenses =SUM_OF_BUYING_EX;
                M_SALES_CASH.Date = DateTime.Now;
                M_SALES_CASH.Electricity_bill = ELECTRICITY_BILL;
                M_SALES_CASH.water_bill = WATER_BILL;
                M_SALES_CASH.Revenue = (decimal)REVENUE;
                M_SALES_CASH.Salary = TOTAL;
                M_SALES_CASH.Gross_income =(decimal)SALES_CASH;
                M_SALES_CASH.Profit =(decimal)PROFIT;
                M_SALES_CASH.Transport = CHECK_TRANSPORT;
                _context.Add(M_SALES_CASH);
                _context.SaveChanges();
                
                swal("Success!", "Monthle sales submitted successfully", "success");

            }
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Expense,Ammount")] Expenses expenses)
        {
            general_class x = new general_class();
            string Month = x.Month(DateTime.Now.ToString("MM/dd/yyyy"));
            //LETS CHECK IF REVENUE HAS BEE SUBMITTED THIS MONTH
            var CHECK_REVENUE = _context.Expenses.Where(j => j.Expense == "Transport" && j.Date.Month.ToString() == Month).Sum(c => c.Ammount);
            if (CHECK_REVENUE != null)
            {
                ViewBag.total_revenue = CHECK_REVENUE;
                ViewBag.hide_button = "1";

            }
            //LETS FIND CARTONS SOLD THIS MONTH
            double SOLD_CARTONS_THIS_MONTH = _context.Cartons_sold.Where(x => x.Date.Month.ToString() == Month).Sum(b => b.Cartons_sold_);
            ViewBag.sold_cartons = SOLD_CARTONS_THIS_MONTH;

            //LETS CALCULATE THE REVENUE
            double REVENUE = 0.05 * (SOLD_CARTONS_THIS_MONTH*300);
            ViewBag.total_rvenue = REVENUE;

            //LETS GET WATER & WATER BILLS
            var WATER_BILL = _context.Expenses.Where(j => j.Expense == "Water" && j.Date.Month.ToString() == Month).Sum(c => c.Ammount);
            ViewBag.water_bill = WATER_BILL;

            //LETS GET ELECTRICITY BILLS 
            var ELECTRICITY_BILL = _context.Expenses.Where(j => j.Expense == "Electricity" && j.Date.Month.ToString() == Month).Sum(c => c.Ammount);
            ViewBag.electricity_bill = ELECTRICITY_BILL;


            //LETS GET SALARY DETAILS
            var GET_SAL = _context.Employees.FirstOrDefault();
            int ALL_EMPLOYEES = GET_SAL.Industry_employees + GET_SAL.Supply_employees;
            decimal SALARY = GET_SAL.Salary;
            decimal TOTAL = ALL_EMPLOYEES * SALARY;
            ViewBag.total_salary = TOTAL;
            ViewBag.salary = SALARY;
            ViewBag.industry_empl = GET_SAL.Industry_employees;
            ViewBag.supply_empl = GET_SAL.Supply_employees;

            if (ModelState.IsValid)
            {
                _context.Add(expenses);
                await _context.SaveChangesAsync();
                swal("Success","Expense added successfully","success");
                return RedirectToAction(nameof(Index));
            }




            return View(expenses);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenses = await _context.Expenses.FindAsync(id);
            if (expenses == null)
            {
                return NotFound();
            }
            return View(expenses);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Expense,Ammount,Date")] Expenses expenses)
        {
            if (id != expenses.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpensesExists(expenses.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(expenses);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenses = await _context.Expenses
                .FirstOrDefaultAsync(m => m.id == id);
            if (expenses == null)
            {
                return NotFound();
            }

            return View(expenses);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenses = await _context.Expenses.FindAsync(id);
            _context.Expenses.Remove(expenses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpensesExists(int id)
        {
            return _context.Expenses.Any(e => e.id == id);
        }
    }
}
