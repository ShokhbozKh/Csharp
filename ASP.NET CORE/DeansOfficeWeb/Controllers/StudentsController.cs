using DeansOfficeWeb.DAL;
using DeansOfficeWeb.Models;
using DeansOfficeWeb.SchoolViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace DeansOfficeWeb.Controllers
{
    public class StudentsController : Controller
    {
        public readonly IDbLayer _context;
        public StudentsController(IDbLayer context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string studyName, string searchString)
        {
            var students = await _context.GetStudents();

            var studies = await _context.GetStudies();

            IQueryable<string> studyQuery = (from s in students
                                             orderby s.Study.Name
                                             select s.Study.Name).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.IndexNumber == searchString).ToList();
            }

            if (!string.IsNullOrEmpty(studyName))
            {
                students = students.Where(s => s.Study.Name == studyName).ToList();
            }


            ViewBag.Students = students;

            ViewBag.Studies = studies;

            var studentStudyView = new StudentStudyViewModel
            {
                StudentsList = students.ToList(),
                Studies = new SelectList(studyQuery.Distinct().ToList()),
                StudentsCount = students.Count()
            };
            
            // int g = 0;
            
            return View(studentStudyView);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var student = await _context.GetStudent(id);

            if(student == null)
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
        public async Task<IActionResult> Create(Student studentToAdd)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", studentToAdd);
            }

            await _context.AddStudent(studentToAdd);

            //int g = 0;

            return RedirectToAction("Create");  // 302
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var student = await _context.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            ViewBag.Studies = await _context.GetStudies();

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("IdStudent,FirstName,LastName,Address,IndexNumber,IdStudy")] Student studentToEdit)
        {
            if (id != studentToEdit.IdStudent)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", studentToEdit);
            }

            await _context.EditStudent(studentToEdit);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var student = await _context.GetStudent(id);
            
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, double d)
        {
            await _context.DeleteStudent(id);

            return RedirectToAction("Index");
        }
    }
}
