using Microsoft.EntityFrameworkCore;
using StudentCourseManagementSystem.Models;

namespace StudentCourseManagementSystem.Services
{
    public class DataSeeder
    {
        private readonly StudentCourseManagementContext _context;

        private Department _computerEngineering = null!;
        private Department _business = null!;

        private Instructor _ahmad = null!;
        private Instructor _sara = null!;
        private Instructor _lina = null!;

        private Course _databases = null!;
        private Course _efCore = null!;
        private Course _webApi = null!;
        private Course _networks = null!;
        private Course _accounting = null!;

        private Student _raghad = null!;
        private Student _omar = null!;
        private Student _noor = null!;
        private Student _mariam = null!;

        public DataSeeder(StudentCourseManagementContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (await DataAlreadyExistsAsync())
                return;

            SeedDepartments();
            SeedInstructors();
            SeedCourses();
            SeedStudents();
            SeedEnrollments();

            await _context.SaveChangesAsync();

            Console.WriteLine("Sample data seeded successfully.");
        }

        private async Task<bool> DataAlreadyExistsAsync()
        {
            return await _context.Students.AnyAsync(s =>
                s.Email == "raghad@example.com");
        }

        private void SeedDepartments()
        {
            _computerEngineering = new Department
            {
                Name = "Computer Engineering"
            };

            _business = new Department
            {
                Name = "Business"
            };

            _context.Departments.AddRange(
                _computerEngineering,
                _business);
        }

        private void SeedInstructors()
        {
            _ahmad = new Instructor
            {
                Name = "Ahmad Khalil",
                Email = "ahmad@university.com",
                Department = _computerEngineering
            };

            _sara = new Instructor
            {
                Name = "Sara Ali",
                Email = "sara@university.com",
                Department = _computerEngineering
            };

            _lina = new Instructor
            {
                Name = "Lina Omar",
                Email = "lina@university.com",
                Department = _business
            };

            _context.Instructors.AddRange(
                _ahmad,
                _sara,
                _lina);
        }

        private void SeedCourses()
        {
            _databases = new Course
            {
                Title = "Database Systems",
                Credits = 3,
                Instructor = _ahmad
            };

            _efCore = new Course
            {
                Title = "Entity Framework Core",
                Credits = 3,
                Instructor = _ahmad
            };

            _webApi = new Course
            {
                Title = "Web API",
                Credits = 3,
                Instructor = _ahmad
            };

            _networks = new Course
            {
                Title = "Computer Networks",
                Credits = 3,
                Instructor = _sara
            };

            _accounting = new Course
            {
                Title = "Accounting Principles",
                Credits = 3,
                Instructor = _lina
            };

            _context.Courses.AddRange(
                _databases,
                _efCore,
                _webApi,
                _networks,
                _accounting);
        }

        private void SeedStudents()
        {
            _raghad = new Student
            {
                Name = "Raghad Shaar",
                Email = "raghad@example.com",
                Department = _computerEngineering
            };

            _omar = new Student
            {
                Name = "Omar Ahmad",
                Email = "omar@example.com",
                Department = _computerEngineering
            };

            _noor = new Student
            {
                Name = "Noor Ali",
                Email = "noor@example.com",
                Department = _computerEngineering
            };

            _mariam = new Student
            {
                Name = "Mariam Khalil",
                Email = "mariam@example.com",
                Department = _business
            };

            _context.Students.AddRange(
                _raghad,
                _omar,
                _noor,
                _mariam);
        }

        private void SeedEnrollments()
        {
            _context.Enrollments.AddRange(
                new Enrollment
                {
                    Student = _raghad,
                    Course = _databases,
                    Grade = 95.50m
                },
                new Enrollment
                {
                    Student = _raghad,
                    Course = _efCore,
                    Grade = 92.00m
                },
                new Enrollment
                {
                    Student = _raghad,
                    Course = _webApi
                },
                new Enrollment
                {
                    Student = _omar,
                    Course = _databases,
                    Grade = 85.75m
                },
                new Enrollment
                {
                    Student = _omar,
                    Course = _webApi,
                    Grade = 88.00m
                },
                new Enrollment
                {
                    Student = _noor,
                    Course = _networks,
                    Grade = 90.25m
                },
                new Enrollment
                {
                    Student = _mariam,
                    Course = _accounting,
                    Grade = 89.50m
                });
        }
    }
}