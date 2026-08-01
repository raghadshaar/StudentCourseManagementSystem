using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagementSystem
{
    public class Course
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }

        [Range(1, 5)]
        public int Credits { get; set; }
    }
}
