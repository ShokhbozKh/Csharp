using DeansOfficeWeb.DAL;
using DeansOfficeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeansOfficeWeb.Controllers
{
    public class StudiesController : Controller
    {
        public readonly IDbLayer _context;

        public StudiesController(IDbLayer context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Studies = await _context.GetStudies();

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var study = await _context.GetStudy(id);

            if (study == null)
            {
                return NotFound();
            }

            return View(study);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Study study)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", study);
            }

            await _context.AddStudy(study);

            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var study = await _context.GetStudy(id);

            if (study == null)
            {
                return NotFound();
            }

            return View(study);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("IdStudy, Name, Duration, Price")] Study studyToEdit)
        {
            if(id != studyToEdit.IdStudy)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", studyToEdit);
            }

            await _context.EditStudy(studyToEdit);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var study = await _context.GetStudy(id);

            return View(study);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, int d)
        {
            await _context.DeleteStudy(id);

            return RedirectToAction(nameof(Index));
        }
    }
}