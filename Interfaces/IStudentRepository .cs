using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseManagementSystem.Models;

namespace StudentCourseManagementSystem.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IReadOnlyList<Student>> GetStudentsWithDepartmentAsync();

        Task<IReadOnlyList<Student>> GetByDepartmentIdAsync(
            int departmentId);

        Task<IReadOnlyList<Course>> GetStudentCoursesAsync(
            int studentId);
    }
}
