using DeansOffice.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Data.Common;
using System.Linq;
using Bogus;
using System.Collections.Generic;

namespace DeansOffice.Data
{
    public class Seed
    {
        public static void Initialize(SchoolContext context, ILogger logger)
        {
            var faker = new Faker();

            try
            {
                context.Database.EnsureCreated();

                // Look for any students.
                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }

                var studentsList = new Student[500];

                for(int i = 0; i < 500; i++)
                {
                    studentsList[i] = new Student
                    {
                        FirstName = faker.Name.FirstName(),
                        LastName = faker.Name.LastName(),
                        StudentNumber = $"u {2021 + i}",
                        EnrollmentDate = faker.Date.Between(new DateTime(2000, 01, 01), new DateTime(2021, 01, 01))
                    };
                }

                int deb = 0;
                context.Students.AddRange(studentsList);
                context.SaveChanges();

                var instructors = new Instructor[50];

                for(int i = 0; i < 50; i++)
                {
                    instructors[i] = new Instructor
                    {
                        FirstName = faker.Name.FirstName(),
                        LastName = faker.Name.LastName(),
                        HireDate = faker.Date.Between(new DateTime(2000, 01, 01), new DateTime(2021, 01, 01))
                    };
                };

                //deb = 0;
                context.AddRange(instructors);
                context.SaveChanges();

                var departments = new Department[]
                {
                new Department
                {
                    Name = "English",
                    Budget = 35000,
                    StartDate = new DateTime(2001,02,11),
                    InstructorId  = instructors.Single(i => i.InstructorId == 1).InstructorId
                },
                new Department 
                { 
                    Name = "Mathematics",
                    Budget = 65200,
                    StartDate = new DateTime(2004,09,10),
                    InstructorId  = instructors.Single( i => i.InstructorId == 13).InstructorId 
                },
                new Department 
                { 
                    Name = "Engineering",
                    Budget = 94000,
                    StartDate = new DateTime(2007,09,5),
                    InstructorId  = instructors.Single( i => i.InstructorId == 5).InstructorId 
                },
                new Department 
                { 
                    Name = "3D Design",
                    Budget = 19000,
                    StartDate = new DateTime(2009,02,04),
                    InstructorId  = instructors.Single( i => i.InstructorId == 20).InstructorId 
                },
                new Department 
                { 
                    Name = "Economics",
                    Budget = 4500,
                    StartDate = new DateTime(2007,09,10),
                    InstructorId  = instructors.Single( i => i.InstructorId == 17).InstructorId 
                },
                new Department 
                { 
                    Name = "Management",
                    Budget = 3000,
                    StartDate = new DateTime(2015,09,10),
                    InstructorId  = instructors.Single( i => i.InstructorId == 24).InstructorId 
                },
                new Department 
                { 
                    Name = "Cyber Security",
                    Budget = 25000,
                    StartDate = new DateTime(2004,07,05),
                    InstructorId  = instructors.Single( i => i.InstructorId == 32).InstructorId 
                },
                new Department 
                { 
                    Name = "Software engineering",
                    Budget = 50000,
                    StartDate = new DateTime(2003,11,01),
                    InstructorId  = instructors.Single( i => i.InstructorId == 45).InstructorId 
                }
                };

                //deb = 0;
                context.Departments.AddRange(departments);
                context.SaveChanges();

                var courses = new Course[]
                {
                    new Course
                    {
                        CourseCode = "4024",
                        Title = "Using correct language for debate",
                        Credits = 4,
                        Price = 350,
                        DepartmentId = departments.Single( s => s.Name == "English").DepartmentId
                    },
                    new Course
                    {
                        CourseCode = "4023",
                        Title = "Advanced writing and grammar",
                        Credits = 6,
                        Price = 350,
                        DepartmentId = departments.Single( s => s.Name == "English").DepartmentId
                    },
                    new Course
                    {
                        CourseCode = "4022",
                        Title = "English",
                        Credits = 4,
                        Price = 300,
                        DepartmentId = departments.Single( s => s.Name == "English").DepartmentId
                    },
                    new Course
                    {
                        CourseCode = "4021",
                        Title = "Literature",
                        Credits = 6,
                        Price = 420,
                        DepartmentId = departments.Single( s => s.Name == "English").DepartmentId
                    },
                    new Course
                    {
                        CourseCode = "1043",
                        Title = "Linear algebra",
                        Credits = 6,
                        Price = 720,
                        DepartmentId = departments.Single( s => s.Name == "Mathematics").DepartmentId
                    },
                    new Course
                    {
                        CourseCode = "1042",
                        Title = "Mathematic analysis",
                        Credits = 6,
                        Price = 450,
                        DepartmentId = departments.Single( s => s.Name == "Mathematics").DepartmentId
                    },
                    new Course
                    {
                        CourseCode = "1041",
                        Title = "Statistics",
                        Credits = 5,
                        Price = 450,
                        DepartmentId = departments.Single( s => s.Name == "Mathematics").DepartmentId
                    },
                    new Course
                    {
                        CourseCode = "1040",
                        Title = "Advanced computing",
                        Credits = 6,
                        Price = 660,
                        DepartmentId = departments.Single( s => s.Name == "Mathematics").DepartmentId
                    },
                    new Course
                    {
                        CourseCode = "1055",
                        Title = "Physics",
                        Credits = 8,
                        Price = 850,
                        DepartmentId = departments.Single( s => s.Name == "Engineering").DepartmentId
                    },
                    new Course
                    {
                        CourseCode = "1054",
                        Title = "Applied engineering",
                        Credits = 6,
                        Price = 650,
                        DepartmentId = departments.Single( s => s.Name == "Engineering").DepartmentId
                    },
                    new Course
                    {
                        CourseCode = "1053",
                        Title = "Mechanical engineering",
                        Credits = 5,
                        Price = 350,
                        DepartmentId = departments.Single( s => s.Name == "Engineering").DepartmentId
                    },
                    new Course
                    {
                        CourseCode = "1052",
                        Title = "Chemical engineering",
                        Credits = 8,
                        Price = 650,
                        DepartmentId = departments.Single( s => s.Name == "Engineering").DepartmentId
                    },
                    new Course
                    {
                        CourseCode = "1011",
                        Title = "Robotics",
                        Credits = 6,
                        Price = 250,
                        DepartmentId = departments.Single( s => s.Name == "Engineering").DepartmentId
                    },
                    new Course
                    {
                        CourseCode = "1010",
                        Title = "Advanced concepts of engineering",
                        Credits = 7,
                        Price = 450,
                        DepartmentId = departments.Single( s => s.Name == "Engineering").DepartmentId
                    },
                };

                //deb = 0;
                context.Courses.AddRange(courses);
                context.SaveChanges();

                var officeAssignments = new OfficeAssignment[instructors.Length];
                var locations = new string[]
                {
                    $"{faker.Address.StateAbbr()}, {faker.Address.StreetName()}",
                    $"{faker.Address.StateAbbr()}, {faker.Address.StreetName()}",
                    $"{faker.Address.StateAbbr()}, {faker.Address.StreetName()}",
                    $"{faker.Address.StateAbbr()}, {faker.Address.StreetName()}",
                    $"{faker.Address.StateAbbr()}, {faker.Address.StreetName()}",
                };

                for (int i = 0; i < instructors.Length; i++)
                {
                    officeAssignments[i] = new OfficeAssignment
                    {
                        InstructorId = instructors[i].InstructorId,
                        Location = locations[i % 5]
                    };
                };

                //deb = 0;
                context.OfficeAssignments.AddRange(officeAssignments);
                context.SaveChanges();

                var courseAssignments = new List<CourseAssignment>();
                int courseIndex = 0;

                for (int i = 0; i < instructors.Length; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (courseIndex == courses.Length) courseIndex = 0;

                        courseAssignments.Add(new CourseAssignment
                        {
                            CourseId = courses[courseIndex].CourseId,
                            InstructorId = instructors.ElementAt(i).InstructorId
                        });
                        courseIndex++;
                    }
                }


                //deb = 0;
                context.AddRange(courseAssignments);
                context.SaveChanges();

                var enrollments = new List<Enrollment>();
                var grades = Enum.GetValues(typeof(Grade)).Cast<Grade>();

                for (int i = 0; i < studentsList.Length; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        enrollments.Add(new Enrollment
                        {
                            StudentId = studentsList.ElementAt(i).StudentId,
                            CourseId = courses[new Random().Next(courses.Length)].CourseId,
                            Grade = grades.ElementAt(new Random().Next(grades.Count()))
                        });
                    }
                }

                //deb = 0;
                context.AddRange(enrollments);
                context.SaveChanges();
            }
            catch(DbException ex)
            {
                logger.LogError(ex, "Error seeding data");
            }
        }
    }
}
