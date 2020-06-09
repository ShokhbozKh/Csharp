using System;
using System.Linq;
using System.Diagnostics;
using BudgetManagement.DAL;
using System.Threading.Tasks;
using BudgetManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BudgetManagement.Models.BudgetViewModels;

namespace BudgetManagement.Controllers
{
    public class HomeController : Controller
    {
        public readonly IDbLayer _context;
        public HomeController(IDbLayer context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string categoryName, string searchString)
        {
            var incomes = await _context.GetIncomes();
            var expenses = await _context.GetExpenses();

            var incomeCategories = await _context.GetIncomeCategories();
            var expenseCategories = await _context.GetExpenseCategories();
            var categories = await _context.GetCategories();

            IQueryable<string> categoryQuery = (from s in categories
                                                select s.Name).AsQueryable();


            if (!string.IsNullOrEmpty(searchString))
            {
                incomes = incomes.Where(s => s.Description == searchString || s.Description.Contains(searchString));
                expenses = expenses.Where(s => s.Description == searchString || s.Description.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(categoryName))
            {
                incomes = incomes.Where(s => s.Category.Name == categoryName).ToList();
                expenses = expenses.Where(s => s.Category.Name == categoryName).ToList();
            }

            var tuple = await GetDates();
            var budgets = await GetBudgets();

            var budgetView = new BudgetViewModel
            {
                IncomesList = incomes,
                ExpensesList = expenses,
                TotalIncome = budgets.Item1,
                TotalExpense = budgets.Item2,
                TotalBudget = budgets.Item3,
                IncomeCategories = new SelectList(incomeCategories.Distinct().ToList()),
                ExpenseCategories = new SelectList(expenseCategories.Distinct().ToList()),
                Categories = new SelectList(categoryQuery.Distinct().ToList()),
                DisplayDate = GetDisplayDate(tuple.Item1, tuple.Item2)
            };

            // int g = 0;

            return View(budgetView);
        }

        public async Task<IActionResult> History(string categoryName, string searchString)
        {
            var histories = await _context.GetHistories();
            var categories = await _context.GetCategories();

            IQueryable<string> categoryQuery = (from s in categories
                                                select s.Name).AsQueryable();


            if (!string.IsNullOrEmpty(searchString))
            {
                histories = histories.Where(s => s.Description == searchString || s.Description.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(categoryName))
            {
                histories = histories.Where(s => s.Category.Name == categoryName).ToList();
            }

            var tuple = await GetHistoryDates();

            var historyView = new HistoryViewModel
            {
                HistoriesList = histories,
                Categories = new SelectList(categoryQuery.Distinct().ToList()),
                DisplayDate = GetDisplayDate(tuple.Item1, tuple.Item2)
            };

            // int g = 0;

            return View(historyView);
        }

        // Get dates for histories
        public async Task<Tuple<DateTime, DateTime>> GetHistoryDates()
        {
            var history = await _context.GetHistories();

            var minDate = history.Select(s => s.DeletedDate).Min();

            var maxDate = history.Select(s => s.DeletedDate).Max();

            return new Tuple<DateTime, DateTime>(minDate, maxDate);
        }

        // Get dates for items
        public async Task<Tuple<DateTime, DateTime>> GetDates()
        {
            var incomes = await _context.GetIncomes();
            var expenses = await _context.GetExpenses();

            var incomesMin = incomes.Select(s => s.AddedDate).Min();
            var expensesMin = expenses.Select(s => s.AddedDate).Min();

            var incomesMax = incomes.Select(s => s.AddedDate).Max();
            var expensesMax = incomes.Select(s => s.AddedDate).Max();

            var minDate = incomesMin < expensesMin ? incomesMin : expensesMin;
            var maxDate = incomesMax > expensesMax ? incomesMax : expensesMax;

            return new Tuple<DateTime, DateTime>(minDate, maxDate);
        }

        /* 
         * If max month is more than min month skip month
         * If max year is more than min year skip min year
         */
        public static string GetDisplayDate(DateTime minDate, DateTime maxDate)
        {
            string fromDate = "";
            string toDate = "";
            int year = 0, month = 0, day = 0;

            if(minDate.Year < maxDate.Year)
            {
                year = minDate.Year;
                month = minDate.Month;
                day = minDate.Day;
            }else if(minDate.Month < maxDate.Month)
            {
                month = minDate.Month;
                day = minDate.Day;
            }else if(minDate.Day <= maxDate.Day)
            {
                day = minDate.Day;
            }

            FormatDate(ref fromDate, year, month, day);
            FormatDate(ref toDate, maxDate.Year, maxDate.Month, maxDate.Day);

            if(fromDate == "ERROR_DATE" || toDate == "ERROR_DATE")
            {
                return "ERROR_DATE";
            }

            return fromDate + "-" + toDate;
        }

        // Format Date
        public static void FormatDate(ref string dateToFormat, int year, int month, int day)
        {
            if (day > 0 && month > 0 && year > 0)
            {
                dateToFormat += day < 10 ? "0" + day + "" : day + "";
                dateToFormat += month < 10 ? ".0" + month + "" : month + "";
                dateToFormat += "." + year;
            }
            else if (day > 0 && month > 0)
            {
                dateToFormat += day < 10 ? "0" + day + "" : day + "";
                dateToFormat += month < 10 ? ".0" + month + "" : month + "";
            }
            else if (day > 0)
            {
                dateToFormat += day < 10 ? "0" + day + "" : day + "";
            }
            else
            {
                dateToFormat = "ERROR_DATE";
            }

        }

        // Calculate total income, expense, budget
        public async Task<Tuple<decimal, decimal, decimal>> GetBudgets()
        {
            var incomes = await _context.GetIncomes();
            var expenses = await _context.GetExpenses();

            decimal inc = incomes.Sum(s => s.TotalSum);
            decimal exp = expenses.Sum(s => s.TotalSum);
            decimal budg = inc - exp;


            return new Tuple<decimal, decimal, decimal>(inc, exp, budg);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
