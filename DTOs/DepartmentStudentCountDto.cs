namespace StudentCourseManagementSystem.DTOs
{
    public class DepartmentStudentCountDto
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; } = null!;

        public int StudentCount { get; set; }
    }
}