using DeansOfficeWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeansOfficeWeb.DAL
{
    public interface IDbLayer
    {
        public Task<IEnumerable<Student>> GetStudents();
        public Task<IEnumerable<Study>> GetStudies();
        public Task<IEnumerable<Subject>> GetSubjects();
        public Task<IEnumerable<Instructor>> GetInstructors();
        public Task<IEnumerable<Enrollment>> GetEnrollments(int? id);
        public Task<IEnumerable<CourseAssignment>> GetCourseAssignments();

        public Task<Student> GetStudent(int? id);

        public Task<Study> GetStudy(int? id);

        public Task<Subject> GetSubject(int? id);

        public Task<Instructor> GetInstructor(int? id);

        public Task<Enrollment> GetEnrollment(int? id);

        // Student
        public Task<Student> AddStudent(Student newStudent);
        public Task<Student> EditStudent(Student studentToEdit);
        public Task<Student> DeleteStudent(int? id);

        // Department
        public Task<Study> AddStudy(Study newStudy);
        public Task<Study> EditStudy(Study studyToEdit);
        public Task<Study> DeleteStudy(int? id);

        // Course
        public Task<Subject> AddSubject(Subject newSubject);
        public Task<Subject> EditSubject(Subject subjectToEdit);
        public Task<Subject> DeleteSubject(int? id);

        // Instructor

        public Task<Instructor> AddInstructor(Instructor newInstructor);
        public Task<Instructor> EditInstructor(Instructor instructorToEdit);
        public Task<Instructor> DeleteInstructor(int? id);

        // Enrollment
        public Task<Enrollment> AddEnrollment(Enrollment newEnrollment);
        public Task<Enrollment> EditEnrollment(Enrollment enrollmentToEdit);
        public Task<Enrollment> DeleteEnrollment(int? grade);
    }
}
