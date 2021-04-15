using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeansOffice.Data;
using DeansOffice.Models;
using DeansOffice.Models.ViewModels;

namespace DeansOffice.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly SchoolContext _context;

        public InstructorsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Instructors
        public async Task<IActionResult> Index(string searchString, string sortBy)
        {
            ViewData["CurrentSearch"] = searchString;
            ViewData["FnameSort"] = string.IsNullOrEmpty(sortBy) ? "fname_desc" : "";
            ViewData["LnameSort"] = sortBy == "lname" ? "lname_desc" : "lname";
            ViewData["HiredateSort"] = sortBy == "hiredate" ? "hiredate_desc" : "hiredate";

            var instructors = _context.Instructors.AsNoTracking().Select(s => new InstructorViewModel
            {
                InstructorId = s.InstructorId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                HireDate = s.HireDate
            });

            if (!string.IsNullOrEmpty(searchString))
            {
                instructors = instructors.Where(s => s.FirstName.Contains(searchString) 
                || s.LastName.Contains(searchString));
            }

            instructors = sortBy switch
            {
                "fname_desc" => instructors.OrderByDescending(s => s.FirstName),
                "lname" => instructors.OrderBy(s => s.LastName),
                "lname_desc" => instructors.OrderByDescending(s => s.LastName),
                "hiredate" => instructors.OrderBy(s => s.HireDate),
                "hiredate_desc" => instructors.OrderByDescending(s => s.HireDate),
                _ => instructors.OrderBy(s => s.FirstName)
            };

            return View(await instructors.ToListAsync());
        }

        // GET: Instructors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                .FirstOrDefaultAsync(m => m.InstructorId == id);

            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // GET: Instructors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instructors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorId,FirstName,LastName,HireDate")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }

        // GET: Instructors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        // POST: Instructors/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructorId,FirstName,LastName,HireDate")] Instructor instructor)
        {
            if (id != instructor.InstructorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorExists(instructor.InstructorId))
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
            return View(instructor);
        }

        // GET: Instructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                .FirstOrDefaultAsync(m => m.InstructorId == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorExists(int id)
        {
            return _context.Instructors.Any(e => e.InstructorId == id);
        }
    }
}
