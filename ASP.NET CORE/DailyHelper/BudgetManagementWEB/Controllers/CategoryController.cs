using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetManagement.DAL;
using BudgetManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManagement.Controllers
{
    public class CategoryController : Controller
    {
        public readonly IDbLayer _context;
        public CategoryController(IDbLayer context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = await _context.GetCategories();

            return View();
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _context.GetCategories();

            ViewBag.Categories = categories.Select(s => s.CategoryType).Distinct();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category newCategory)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newCategory);
            }

            await _context.AddCategory(newCategory);

            return RedirectToAction("Index");
        }
    }
}