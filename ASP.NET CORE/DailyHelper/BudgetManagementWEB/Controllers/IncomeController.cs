using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BudgetManagement.DAL;
using BudgetManagement.Models;

namespace BudgetManagement.Controllers
{
    public class IncomeController : Controller
    {
        public readonly IDbLayer _context;

        public IncomeController(IDbLayer context)
        {
            _context = context;
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.GetIncomeCategories();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Income incomeToAdd)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", incomeToAdd);
            }

            await _context.AddIncome(incomeToAdd);

            // int g = 0;

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id is null)
            {
                return NotFound();
            }

            var income = await _context.GetIncome(id);

            if(income is null)
            {
                return NotFound();
            }

            ViewBag.Categories = await _context.GetIncomeCategories();

            return View(income);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("IdIncome, AddedDate, Description, TotalSum, CategoryId")] Income incomeToEdit)
        {
            if(id != incomeToEdit.IdIncome)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", incomeToEdit);
            }

            await _context.EditIncome(incomeToEdit);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var income = await _context.GetIncome(id);

            return View(income);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, int g)
        {
            await _context.DeleteIncome(id);

            return RedirectToAction("Index", "Home");
        }
    }
}