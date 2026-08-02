using Microsoft.EntityFrameworkCore;
using StudentCourseManagementSystem.Interfaces;

namespace StudentCourseManagementSystem.Services
{
    public class DemoRunner
    {
        private readonly StudentCourseManagementContext _context;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public DemoRunner(
            StudentCourseManagementContext context,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IInstructorRepository instructorRepository,
            IDepartmentRepository departmentRepository)
        {
            _context = context;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _instructorRepository = instructorRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task RunAsync()
        {
            int departmentId = await GetComputerEngineeringDepartmentIdAsync();
            int studentId = await GetRaghadIdAsync();

            await ShowStudentsWithDepartmentAsync();
            await ShowCoursesWithInstructorAsync();
            await ShowInstructorsByDepartmentAsync(departmentId);
            await ShowStudentCoursesAsync(studentId);
            await ShowStudentsByDepartmentAsync(departmentId);
            await ShowStudentCountPerDepartmentAsync();
            await ShowCourseCountPerInstructorAsync();
            await ShowBusyInstructorsAsync();
            await ShowLargestDepartmentAsync();
        }

        private async Task<int> GetComputerEngineeringDepartmentIdAsync()
        {
            return await _context.Departments
                .Where(d => d.Name == "Computer Engineering")
                .Select(d => d.Id)
                .FirstAsync();
        }

        private async Task<int> GetRaghadIdAsync()
        {
            return await _context.Students
                .Where(s => s.Email == "raghad@example.com")
                .Select(s => s.Id)
                .FirstAsync();
        }

        private async Task ShowStudentsWithDepartmentAsync()
        {
            Console.WriteLine("\n1. Students with their Department");

            var students =
                await _studentRepository.GetStudentsWithDepartmentAsync();

            foreach (var student in students)
            {
                Console.WriteLine(
                    $"{student.Name} - {student.Department.Name}");
            }
        }

        private async Task ShowCoursesWithInstructorAsync()
        {
            Console.WriteLine("\n2. Courses with their Instructor");

            var courses =
                await _courseRepository.GetAllWithInstructorAsync();

            foreach (var course in courses)
            {
                Console.WriteLine(
                    $"{course.Title} - {course.Instructor.Name}");
            }
        }

        private async Task ShowInstructorsByDepartmentAsync(int departmentId)
        {
            Console.WriteLine("\n3. Instructors in Computer Engineering");

            var instructors =
                await _instructorRepository
                    .GetByDepartmentIdAsync(departmentId);

            foreach (var instructor in instructors)
            {
                Console.WriteLine(instructor.Name);
            }
        }

        private async Task ShowStudentCoursesAsync(int studentId)
        {
            Console.WriteLine("\n4. Courses taken by Raghad");

            var courses =
                await _studentRepository
                    .GetStudentCoursesAsync(studentId);

            foreach (var course in courses)
            {
                Console.WriteLine(
                    $"{course.Title} - {course.Instructor.Name}");
            }
        }

        private async Task ShowStudentsByDepartmentAsync(int departmentId)
        {
            Console.WriteLine("\n5. Students in Computer Engineering");

            var students =
                await _studentRepository
                    .GetByDepartmentIdAsync(departmentId);

            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
            }
        }

        private async Task ShowStudentCountPerDepartmentAsync()
        {
            Console.WriteLine("\n6. Student Count Per Department");

            var result =
                await _departmentRepository
                    .GetStudentCountsAsync();

            foreach (var item in result)
            {
                Console.WriteLine(
                    $"{item.DepartmentName} : {item.StudentCount}");
            }
        }

        private async Task ShowCourseCountPerInstructorAsync()
        {
            Console.WriteLine("\n7. Course Count Per Instructor");

            var result =
                await _instructorRepository
                    .GetCourseCountsAsync();

            foreach (var item in result)
            {
                Console.WriteLine(
                    $"{item.InstructorName} : {item.CourseCount}");
            }
        }

        private async Task ShowBusyInstructorsAsync()
        {
            Console.WriteLine("\n8. Instructors Teaching More Than 2 Courses");

            var instructors =
                await _instructorRepository
                    .GetInstructorsTeachingMoreThanAsync(2);

            foreach (var instructor in instructors)
            {
                Console.WriteLine(instructor.Name);
            }
        }

        private async Task ShowLargestDepartmentAsync()
        {
            Console.WriteLine(
                "\n9. Department With Highest Student Count");

            var department =
                await _departmentRepository
                    .GetDepartmentWithMostStudentsAsync();

            if (department != null)
            {
                Console.WriteLine(department.Name);
            }
        }
    }
}