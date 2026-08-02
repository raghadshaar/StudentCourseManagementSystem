using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentCourseManagementSystem
{
    [Index(nameof(StudentId), nameof(CourseId), IsUnique = true)]
    public class Enrollment
    {
        public int Id { get; set; }
        [Precision(5, 2)]
        public decimal? Grade { get; set; } 
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public int CourseId { get; set; }
        public Course Course { get; set;} = null!;
     
    }
}
