using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseManagementSystem.DTOs;
using StudentCourseManagementSystem.Models;

namespace StudentCourseManagementSystem.Interfaces
{
    public interface IInstructorRepository : IRepository<Instructor>
    {
        Task<IReadOnlyList<Instructor>>
            GetByDepartmentIdAsync(int departmentId);

        Task<IReadOnlyList<InstructorCourseCountDto>>
            GetCourseCountsAsync();

        Task<IReadOnlyList<Instructor>>
            GetInstructorsTeachingMoreThanAsync(int courseCount);
    }
}
