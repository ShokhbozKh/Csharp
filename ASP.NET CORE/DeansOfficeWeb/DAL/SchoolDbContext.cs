using DeansOfficeWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DeansOfficeWeb.DAL
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student", schema: "School");
            modelBuilder.Entity<Study>().ToTable("Department", schema: "School");
            modelBuilder.Entity<Subject>().ToTable("Course", schema: "School");
            modelBuilder.Entity<Instructor>().ToTable("Instructor", schema: "School");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment", schema: "School");
            modelBuilder.Entity<CourseAssignment>().ToTable("Course_Assignment", schema: "School");

            base.OnModelCreating(modelBuilder);
        }
    }
}
