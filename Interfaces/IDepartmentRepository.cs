using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseManagementSystem.DTOs;
using StudentCourseManagementSystem.Models;

namespace StudentCourseManagementSystem.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IReadOnlyList<DepartmentStudentCountDto>>GetStudentCountsAsync();
        Task<Department?> GetDepartmentWithMostStudentsAsync();
    }
}
