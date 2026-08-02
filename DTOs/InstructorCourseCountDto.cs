namespace StudentCourseManagementSystem.DTOs
{
    public class InstructorCourseCountDto
    {
        public int InstructorId { get; set; }

        public string InstructorName { get; set; } = null!;

        public int CourseCount { get; set; }
    }
}