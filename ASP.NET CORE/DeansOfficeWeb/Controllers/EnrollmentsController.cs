using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeansOfficeWeb.DAL;
using DeansOfficeWeb.Models;
using DeansOfficeWeb.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeansOfficeWeb.Controllers
{
    public class EnrollmentsController : Controller
    {
        public readonly IDbLayer _context;

        public EnrollmentsController(IDbLayer context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var enrollments = await _context.GetEnrollments(id);

            ViewBag.Enrollments = enrollments;

            if(id != null)
            {
                var student = enrollments.Where(e => e.IdStudent == id).FirstOrDefault();

                ViewBag.IdStudent = student.IdStudent;
            }

            int g = 0;

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.GetEnrollment(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            //int g = 0;

            return View(enrollment);
        }

        public async Task<IActionResult> Create(int? id)
        {
            var students = await _context.GetStudents();
            var subjects = await _context.GetSubjects();
            var instructors = await _context.GetInstructors();

            if(id != null)
            {
                students = students.Where(s => s.IdStudent == id);
            }

            ViewBag.Students = students;
            ViewBag.Subjects = subjects;
            ViewBag.Instructors = instructors;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Enrollment newEnrollment)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newEnrollment);
            }

            await _context.AddEnrollment(newEnrollment);

            return RedirectToAction("Create");
        }

        /// <summary>
        ///  TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.GetEnrollment(id);

            if(enrollment == null)
            {
                return NotFound();
            }

            ViewBag.Subjects = await _context.GetSubjects();
            ViewBag.Students = await _context.GetStudents();
            ViewBag.Instructors = await _context.GetInstructors();

            return View(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("IdEnrollment, Grade, SubjectType, EnrollmentDate, IdSubject, IdStudent, IdInstructor")] Enrollment enrollmentToEdit)
        {
            if(id != enrollmentToEdit.IdEnrollment)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", enrollmentToEdit);
            }

            await _context.EditEnrollment(enrollmentToEdit);

            return RedirectToAction("Index", id); 
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            
            var enrollment = await _context.GetEnrollment(id);

            if(enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, double d)
        {
            await _context.DeleteEnrollment(id);

            return RedirectToAction("Index");
        }
    }
}