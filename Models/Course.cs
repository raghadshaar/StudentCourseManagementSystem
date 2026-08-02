using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Title { get; set; } = null!;

        [Range(1, 5)]
        public int Credits { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;
        public ICollection<Enrollment> Enrollments { get; set; }
       = new List<Enrollment>();

    }
}
