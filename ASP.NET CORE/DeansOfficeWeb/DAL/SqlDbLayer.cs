using DeansOfficeWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeansOfficeWeb.DAL
{
    public class SqlDbLayer : IDbLayer
    {
        public readonly SchoolDbContext _context;

        public Task<IEnumerable<Instructor>> Instructors { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public SqlDbLayer(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetStudent(int? id)
        {
            var students = await _context.Students.Include(s => s.Study).ToListAsync();

            return students.Find(s => s.IdStudent == id);
        }

        public async Task<Study> GetStudy(int? id)
        {
            var studies = await _context.Studies.ToListAsync();

            return studies.Find(s => s.IdStudy == id);
        }

        public async Task<Subject> GetSubject(int? id)
        {
            var subjects = await _context.Subjects.ToListAsync();

            return subjects.Find(s => s.IdSubject == id);
        }

        public async Task<Instructor> GetInstructor(int? id)
        {
            var instructors = await _context.Instructors.ToListAsync();

            return instructors.Find(s => s.IdInstructor == id);
        }

        public async Task<Enrollment> GetEnrollment(int? id)
        {
            var enrollemnts = await _context.Enrollments
                .Include(e => e.Student)
                .ThenInclude(e => e.Study)
                .Include(e => e.Subject)
                .Include(e => e.Instructor)
                .ToListAsync();

            return enrollemnts.Find(s => s.IdEnrollment == id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students
                .Include(s => s.Study)
                .OrderBy(s => s.FirstName)
                .ThenBy(s => s.LastName)
                .ThenBy(s => s.IndexNumber)
                .ThenBy(s => s.Study.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Study>> GetStudies()
        {
            return await _context.Studies
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await _context.Subjects
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Instructor>> GetInstructors()
        {
            return await _context.Instructors
                .Include(i => i.CourseAssignments)
                .OrderBy(i => i.FirstName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollments(int? id)
        {
            if(id != null)
            {
                return await _context.Enrollments
                    .Include(e => e.Student)
                    .ThenInclude(e => e.Study)
                    .Include(e => e.Subject)
                    .Include(e => e.Instructor)
                    .OrderBy(e => e.IdEnrollment)
                    .Where(e => e.IdStudent == id)
                    .ToListAsync();
            } 
            else
            {
                return await _context.Enrollments
                .Include(e => e.Student)
                .ThenInclude(e => e.Study)
                .Include(e => e.Subject)
                .Include(e => e.Instructor)
                .OrderBy(e => e.IdEnrollment)
                .ToListAsync();
            }
        }

        public async Task<IEnumerable<CourseAssignment>> GetCourseAssignments()
        {
            return await _context.CourseAssignments
                .Include(c => c.Instructor)
                .Include(c => c.Subject)
                .ToListAsync();
        }

        public async Task<Student> AddStudent(Student newStudent)
        {
            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();

            return newStudent;
        }

        public async Task<Study> AddStudy(Study newStudy)
        {
            _context.Studies.Add(newStudy);
            await _context.SaveChangesAsync();

            return newStudy;
        }

        public async Task<Subject> AddSubject(Subject newSubject)
        {
            _context.Subjects.Add(newSubject);
            await _context.SaveChangesAsync();

            return newSubject;
        }

        public async Task<Instructor> AddInstructor(Instructor newInstructor)
        {
            _context.Instructors.Add(newInstructor);
            await _context.SaveChangesAsync();

            return newInstructor;
        }

        public async Task<Enrollment> AddEnrollment(Enrollment newEnrollment)
        {
            _context.Enrollments.Add(newEnrollment);
            await _context.SaveChangesAsync();

            return newEnrollment;
        }

        public async Task<Student> DeleteStudent(int? id)
        {
            var studentToDelete = await _context.Students.FindAsync(id);
            _context.Students.Remove(studentToDelete);
            await _context.SaveChangesAsync();

            // int g = 0;

            _context.Remove(studentToDelete);

            return null;
        }

        public async Task<Study> DeleteStudy(int? id)
        {
            var studyToDelete = await _context.Studies.FindAsync(id);
            _context.Studies.Remove(studyToDelete);
            await _context.SaveChangesAsync();

            // int g = 0;

            _context.Remove(studyToDelete);

            return null;
        }

        public async Task<Subject> DeleteSubject(int? id)
        {
            var subjectToDelete = _context.Subjects.Find(id);
            _context.Subjects.Remove(subjectToDelete);
            await _context.SaveChangesAsync();

            _context.Remove(subjectToDelete);

            return null;

        }

        public async Task<Instructor> DeleteInstructor(int? id)
        {
            var instructorToDelete = _context.Instructors.Find(id);
            _context.Instructors.Remove(instructorToDelete);
            await _context.SaveChangesAsync();

            _context.Remove(instructorToDelete);

            return null;
        }

        public async Task<Enrollment> DeleteEnrollment(int? id)
        {
            var enrollmentToDelete = _context.Enrollments.Find(id);
            _context.Enrollments.Remove(enrollmentToDelete);
            await _context.SaveChangesAsync();

            _context.Remove(enrollmentToDelete);

            return null;
        }

        public async Task<Student> EditStudent(Student studentToEdit)
        {
            _context.Update(studentToEdit);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Study> EditStudy(Study studyToEdit)
        {
            _context.Update(studyToEdit);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Subject> EditSubject(Subject subjectToEdit)
        {
            _context.Update(subjectToEdit);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Instructor> EditInstructor(Instructor instructorToEdit)
        {
            _context.Update(instructorToEdit);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Enrollment> EditEnrollment(Enrollment enrollmentToEdit)
        {
            _context.Update(enrollmentToEdit);
            await _context.SaveChangesAsync();

            return null;
        }
    }
}
