using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeansOffice.Data;
using DeansOffice.Models;
using DeansOffice.Helpers;

namespace DeansOffice.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index(string sortOrder, string searchString,
            string currentSearch, int? pageNumber)
        {
            // Save current sorting, filtering queries for navigation,
            // in order not to lose queries on paagination
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentSearch"] = searchString;
            ViewData["FNameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["LNameSortParam"] = sortOrder == "lname" ? "lname_desc" : "lname";
            ViewData["SNumberSortParam"] = sortOrder == "snumber" ? "snumber_desc" : "snumber";
            ViewData["DateSortParam"] = sortOrder == "date" ? "date_desc" : "date";

            // If there is a new search, set the page to 1,
            // During paagination the search string is passed to currentSearch
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentSearch;
            }

            IQueryable<Student> students = _context.Students;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                students = students.Where(s => s.FirstName.Contains(searchString)
                                          || s.LastName.Contains(searchString));
            }

            students = sortOrder switch
            {
                "name_desc" => students.OrderByDescending(s => s.FirstName),
                "lname" => students.OrderBy(s => s.LastName),
                "lname_desc" => students.OrderByDescending(s => s.LastName),
                "snumber" => students.OrderBy(s => s.StudentNumber),
                "snumber_desc" => students.OrderByDescending(s => s.StudentNumber),
                "date" => students.OrderBy(s => s.EnrollmentDate),
                "date_desc" => students.OrderByDescending(s => s.EnrollmentDate),
                _ => students.OrderBy(s => s.FirstName)
            };

            int pageSize = 10;

            // Set number of students found after filter

            return View(await PaginatedList<Student>
                .CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id, string sortOrder)
        {
            ViewData["StudentSort"] = string.IsNullOrEmpty(sortOrder) ? "student_desc" : "";
            ViewData["GradeSort"] = sortOrder == "grade" ? "grade_desc" : "grade";
            ViewData["CourseCodeSort"] = sortOrder == "code" ? "code_desc" : "code";

            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.StudentId == id);

            student.Enrollments = sortOrder switch
            {
                "student_desc" => student.Enrollments.OrderByDescending(e => e.Course.Title).ToList(),
                "grade" => student.Enrollments.OrderBy(e => e.Grade).ToList(),
                "grade_desc" => student.Enrollments.OrderByDescending(e => e.Grade).ToList(),
                "code" => student.Enrollments.OrderBy(e => e.Course.CourseCode).ToList(),
                "code_desc" => student.Enrollments.OrderByDescending(e => e.Course.CourseCode).ToList(),
                _ => student.Enrollments.OrderBy(e => e.Course.Title).ToList()
            };

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,EnrollmentDate")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction(nameof(Index));
                }
                return View(student);
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists" +
                    "see your system administrator.");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Updating Student failed." +
                    "Try again, if the problem persists see your administrator";
            }

            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var studentToUpdate = await _context.Students
                .FindAsync(id);

            if(await TryUpdateModelAsync<Student>(
                studentToUpdate,
                "",
                s => s.FirstName, s => s.LastName, s => s.EnrollmentDate))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem presists see your administrator");
                }
            }

            return View(studentToUpdate);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            if(saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed." +
                    "Try again, and if the problem persists see your administrator.";
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if(student == null)
            {
                return NotFound();
            }

            try
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id, saveChangesError = true });
            }
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
