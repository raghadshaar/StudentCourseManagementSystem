using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentCourseManagementSystem.Models;

namespace StudentCourseManagementSystem
{
    public class StudentCourseManagementContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=StudentCourseManagement;
                                        Integrated Security=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
               .HasOne(student => student.Department)
               .WithMany(department => department.Students)
               .HasForeignKey(student => student.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Instructor>()
                .HasOne(instructor => instructor.Department)
                .WithMany(department => department.Instructors)
                .HasForeignKey(instructor => instructor.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasOne(course => course.Instructor)
                .WithMany(instructor => instructor.Courses)
                .HasForeignKey(course => course.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
