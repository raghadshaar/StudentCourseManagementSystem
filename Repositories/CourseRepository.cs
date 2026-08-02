using Microsoft.EntityFrameworkCore;
using StudentCourseManagementSystem.Interfaces;
using StudentCourseManagementSystem.Models;

namespace StudentCourseManagementSystem.Repositories
{
    public class CourseRepository
        : Repository<Course>, ICourseRepository
    {
        public CourseRepository(
            StudentCourseManagementContext context)
            : base(context)
        {
        }

        public async Task<IReadOnlyList<Course>>
            GetAllWithInstructorAsync()
        {
            return await _context.Courses
                .AsNoTracking()
                .Include(course => course.Instructor)
                .ToListAsync();
        }
    }
}