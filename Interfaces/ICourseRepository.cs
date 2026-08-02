using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseManagementSystem.Models;

namespace StudentCourseManagementSystem.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IReadOnlyList<Course>>
            GetAllWithInstructorAsync();
    }
}
