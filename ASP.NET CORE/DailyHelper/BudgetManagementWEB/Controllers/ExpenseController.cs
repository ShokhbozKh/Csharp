using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BudgetManagement.DAL;
using BudgetManagement.Models;

namespace BudgetManagement.Controllers
{
    public class ExpenseController : Controller
    {
        public readonly IDbLayer _context;
        public ExpenseController(IDbLayer context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.GetExpenseCategories();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expenseToAdd)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", expenseToAdd);
            }

            await _context.AddExpense(expenseToAdd);

            // int g = 0;

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var expense = await _context.GetExpense(id);

            if (expense is null)
            {
                return NotFound();
            }

            ViewBag.Categories = await _context.GetExpenseCategories();

            int g = 0;

            return View(expense);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("IdExpense, AddedDate, Description, TotalSum, CategoryId")] Expense expenseToEdit)
        {
            if (id != expenseToEdit.IdExpense)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", expenseToEdit);
            }

            await _context.EditExpense(expenseToEdit);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var income = await _context.GetExpense(id);

            return View(income);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, int g)
        {
            await _context.DeleteExpense(id);

            return RedirectToAction("Index", "Home");
        }

    }
}