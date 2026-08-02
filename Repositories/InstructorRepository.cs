using Microsoft.EntityFrameworkCore;
using StudentCourseManagementSystem.DTOs;
using StudentCourseManagementSystem.Interfaces;
using StudentCourseManagementSystem.Models;

namespace StudentCourseManagementSystem.Repositories
{
    public class InstructorRepository
        : Repository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(
            StudentCourseManagementContext context)
            : base(context)
        {
        }

        public async Task<IReadOnlyList<Instructor>>
            GetByDepartmentIdAsync(int departmentId)
        {
            return await _context.Instructors
                .AsNoTracking()
                .Where(instructor =>
                    instructor.DepartmentId == departmentId)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<InstructorCourseCountDto>>
            GetCourseCountsAsync()
        {
            return await _context.Instructors
                .AsNoTracking()
                .Select(instructor =>
                    new InstructorCourseCountDto
                    {
                        InstructorId = instructor.Id,
                        InstructorName = instructor.Name,
                        CourseCount = instructor.Courses.Count()
                    })
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Instructor>>
            GetInstructorsTeachingMoreThanAsync(int courseCount)
        {
            return await _context.Instructors
                .AsNoTracking()
                .Where(instructor =>
                    instructor.Courses.Count() > courseCount)
                .ToListAsync();
        }
    }
}