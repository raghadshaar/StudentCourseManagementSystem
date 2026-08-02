using global::StudentCourseManagementSystem.Interfaces;
using global::StudentCourseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentCourseManagementSystem.Repositories
{
    public class StudentRepository
        : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudentCourseManagementContext context): base(context)
        {}

        public async Task<IReadOnlyList<Student>>
            GetStudentsWithDepartmentAsync()
        {
            return await _context.Students
                .AsNoTracking()
                .Include(student => student.Department)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Student>>
            GetByDepartmentIdAsync(int departmentId)
        {
            return await _context.Students
                .AsNoTracking()
                .Where(student =>
                    student.DepartmentId == departmentId)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Course>>
            GetStudentCoursesAsync(int studentId)
        {
            return await _context.Courses
                .AsNoTracking()
                .Where(course =>
                    course.Enrollments.Any(enrollment =>
                        enrollment.StudentId == studentId))
                .Include(course => course.Instructor)
                .ToListAsync();
        }
    }
}

