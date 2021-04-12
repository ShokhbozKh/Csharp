using DeansOffice.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Data.Common;
using System.Linq;

namespace DeansOffice.Data
{
    public class Seed
    {
        public static void Initialize(SchoolContext context, ILogger logger)
        {
            try
            {
                context.Database.EnsureCreated();

                // Look for any students.
                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }

                var students = new Student[]
                {
                    new Student{FirstName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                    new Student{FirstName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                    new Student{FirstName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                    new Student{FirstName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                    new Student{FirstName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
                };

                context.Students.AddRange(students);
                context.SaveChanges();

                var courses = new Course[]
                {
                    new Course{Title="Chemistry",Credits=3},
                    new Course{Title="Microeconomics",Credits=3},
                    new Course{Title="Macroeconomics",Credits=3},
                    new Course{Title="Calculus",Credits=4},
                    new Course{Title="Trigonometry",Credits=4},
                    new Course{Title="Composition",Credits=3},
                    new Course{Title="Literature",Credits=4}
                };

                context.Courses.AddRange(courses);
                context.SaveChanges();

                var enrollments = new Enrollment[]
                {
                    new Enrollment{StudentId=1,CourseId=2,Grade=Grade.A},
                    new Enrollment{StudentId=1,CourseId=7,Grade=Grade.C},
                    new Enrollment{StudentId=1,CourseId=4,Grade=Grade.B},
                    new Enrollment{StudentId=2,CourseId=5,Grade=Grade.B},
                    new Enrollment{StudentId=2,CourseId=3,Grade=Grade.F},
                    new Enrollment{StudentId=2,CourseId=2,Grade=Grade.F},
                    new Enrollment{StudentId=3,CourseId=5},
                    new Enrollment{StudentId=4,CourseId=1},
                    new Enrollment{StudentId=4,CourseId=4,Grade=Grade.F},
                    new Enrollment{StudentId=5,CourseId=46,Grade=Grade.C},
                    new Enrollment{StudentId=6,CourseId=7},
                    new Enrollment{StudentId=7,CourseId=3,Grade=Grade.A},
                };
                foreach (Enrollment e in enrollments)
                {
                    context.Enrollments.Add(e);
                }
                context.SaveChanges();
            }
            catch(DbException ex)
            {
                logger.LogError(ex, "Error seeding data");
            }
        }
    }
}
