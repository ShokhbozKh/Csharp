using DeansOffice.Models;
using Microsoft.EntityFrameworkCore;

namespace DeansOffice.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) :
            base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<CourseAssignment> CourseAssignments { get; set; }
        public virtual DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");

            /*
             *  Validation rules
             */

            // Student
            modelBuilder.Entity<Student>()
                .Property(s => s.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Student>()
                .Property(s => s.LastName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Student>()
                .Ignore(s => s.FullName);
            modelBuilder.Entity<Student>()
                .Property(s => s.EnrollmentDate).HasColumnType("Date").IsRequired();

            // Course
            modelBuilder.Entity<Course>()
                .Property(c => c.Title).IsRequired();
            modelBuilder.Entity<Course>()
                .Property(c => c.CourseCode).IsRequired();
            modelBuilder.Entity<Course>()
                .Property(c => c.Credits).IsRequired();
            modelBuilder.Entity<Course>()
                .Property(c => c.Price).HasColumnType("decimal").HasPrecision(18, 2).IsRequired();
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId);
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Enrollments)
                .WithOne(e => e.Course);
            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseAssignments)
                .WithOne(ca => ca.Course);
            modelBuilder.Entity<Course>();

            // Instructor
            modelBuilder.Entity<Instructor>()
                .Property(i => i.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Instructor>()
                .Property(i => i.LastName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Instructor>()
                .Property(i => i.HireDate).HasColumnType("date").IsRequired();
            modelBuilder.Entity<Instructor>()
                .Ignore(i => i.FullName);
            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.CourseAssignments)
                .WithOne(ca => ca.Instructor);
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.OfficeAssignment)
                .WithOne(oa => oa.Instructor);

            // Course Assignment
            modelBuilder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseId, c.InstructorId });
            modelBuilder.Entity<CourseAssignment>()
                .HasOne(ca => ca.Course)
                .WithMany(c => c.CourseAssignments)
                .HasForeignKey(ca => ca.CourseId);
            modelBuilder.Entity<CourseAssignment>()
                .HasOne(ca => ca.Instructor)
                .WithMany(i => i.CourseAssignments)
                .HasForeignKey(ca => ca.InstructorId);

            // Department
            modelBuilder.Entity<Department>()
                .Property(d => d.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Department>()
                .Property(d => d.Budget).HasColumnType<decimal>("decimal").HasPrecision(18, 2).IsRequired();
            modelBuilder.Entity<Department>()
                .Property(d => d.StartDate).HasColumnType("Date").IsRequired();
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Administrator)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Courses)
                .WithOne(c => c.Department)
                .HasForeignKey(c => c.DepartmentId);

            // Enrollments
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => e.EnrollmentId);
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);
            modelBuilder.Entity<Enrollment>()
                .Property(e => e.Grade).IsRequired(false);
            modelBuilder.Entity<Enrollment>()
                .Property(e => e.EnrollmentDate).IsRequired().HasColumnType("date");

            // Office Assignment
            modelBuilder.Entity<OfficeAssignment>()
                .HasKey(oa => oa.InstructorId);
            modelBuilder.Entity<OfficeAssignment>()
                .Property(oa => oa.Location).HasMaxLength(250).IsRequired();
            modelBuilder.Entity<OfficeAssignment>()
                .HasOne(oa => oa.Instructor)
                .WithOne(i => i.OfficeAssignment);

            base.OnModelCreating(modelBuilder);
        }
    }
}
