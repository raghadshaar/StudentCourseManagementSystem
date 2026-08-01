using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagementSystem
{
    public class Student
    {
        public int Id { get; set; }
        [MaxLength(100)]

        public string Name { get; set; }
        [EmailAddress]
        [MaxLength(300)]
        public string Email { get; set; }
    }
}
