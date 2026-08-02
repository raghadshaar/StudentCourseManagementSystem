using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagementSystem
{
    public class Instructor
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [EmailAddress]
        [MaxLength(254)]
        public string Email { get; set; } = null!;
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public ICollection<Course> Courses { get; set; }
            = new List<Course>();
    }
}
