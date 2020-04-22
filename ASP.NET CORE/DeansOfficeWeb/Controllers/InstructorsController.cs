using DeansOfficeWeb.DAL;
using DeansOfficeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeansOfficeWeb.Controllers
{
    public class InstructorsController : Controller
    {
        public readonly IDbLayer _context;

        public InstructorsController(IDbLayer context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var instructors = await _context.GetInstructors();

            ViewBag.Instructors = instructors;

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.GetInstructor(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Studies = await _context.GetStudies();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Instructor instructorToAdd)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", instructorToAdd);
            }

            await _context.AddInstructor(instructorToAdd);

            //int g = 0;

            return RedirectToAction("Create");  // 302
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.GetInstructor(id);

            if (student == null)
            {
                return NotFound();
            }

            ViewBag.Studies = await _context.GetStudies();

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("IdInstructor,FirstName,LastName,HireDate")] Instructor instructorToEdit)
        {
            if (id != instructorToEdit.IdInstructor)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", instructorToEdit);
            }

            await _context.EditInstructor(instructorToEdit);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var student = await _context.GetInstructor(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, double d)
        {
            await _context.DeleteInstructor(id);

            return RedirectToAction("Index");
        }
    }
}
