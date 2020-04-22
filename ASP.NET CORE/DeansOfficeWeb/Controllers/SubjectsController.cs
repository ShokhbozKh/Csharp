using DeansOfficeWeb.DAL;
using DeansOfficeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeansOfficeWeb.Controllers
{
    public class SubjectsController : Controller
    {
        public readonly IDbLayer _context;

        public SubjectsController(IDbLayer context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Subjects = await _context.GetSubjects();

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            var subject = await _context.GetSubject(id);

            return View(subject);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", subject);
            }

            await _context.AddSubject(subject);

            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var subject = await _context.GetSubject(id);

            if(subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("IdSubject, Name, Hours, Price, Credits")] Subject subjectToEdit)
        {
            if(id != subjectToEdit.IdSubject)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", subjectToEdit);
            }

            await _context.EditSubject(subjectToEdit);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var subject = await _context.GetSubject(id);

            return View(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, int g)
        {
            await _context.DeleteSubject(id);

            return RedirectToAction("Index");
        }
    }
}