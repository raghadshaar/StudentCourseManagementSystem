using Microsoft.EntityFrameworkCore;
using StudentCourseManagementSystem.DTOs;
using StudentCourseManagementSystem.Interfaces;
using StudentCourseManagementSystem.Models;

namespace StudentCourseManagementSystem.Repositories
{
    public class DepartmentRepository
        : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(StudentCourseManagementContext context): base(context){}

        public async Task<IReadOnlyList<DepartmentStudentCountDto>>
            GetStudentCountsAsync()
        {
            return await _context.Departments
                .AsNoTracking()
                .Select(department =>
                    new DepartmentStudentCountDto
                    {
                        DepartmentId = department.Id,
                        DepartmentName = department.Name,
                        StudentCount = department.Students.Count()
                    })
                .ToListAsync();
        }

        public async Task<Department?>
            GetDepartmentWithMostStudentsAsync()
        {
            return await _context.Departments
                .AsNoTracking()
                .OrderByDescending(department =>
                    department.Students.Count())
                .ThenBy(department => department.Id)
                .FirstOrDefaultAsync();
        }
    }
}