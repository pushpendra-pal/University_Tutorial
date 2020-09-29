using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Models;

//Generated automatically, using Scaffolding the Pages/Students/ Student Model
namespace University.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        //the above table was generated automatically after scaffolding operation
        //Now adding other tables too, to the same DB

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        //Adding the below code(not automatically generated

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<Department>()
                .ToTable("Department")
                .HasOne(d => d.Administrator)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");

            modelBuilder.Entity<CourseAssignment>()
                .ToTable("CourseAssignment")
                .HasKey(c => new { c.CourseID, c.InstructorID });
            //The above one creates a composite key

            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
           
            /* In that case, the department would be deleted when the instructor assigned as its administrator is deleted. 
             * In this scenario, a restrict rule would make more sense. 
             * The above code is fluent API that would set a restrict rule and disable cascade delete.*/
            // In EF Core, DbSet is a table, also called EntitySet
            // And an ENTITY is a ROW in the table
        }
    }
}
