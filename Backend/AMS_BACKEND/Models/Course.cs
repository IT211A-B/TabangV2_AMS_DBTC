namespace AMS_BACKEND.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = "";
        public string Department { get; set; } = "";
        public string Units { get; set; } = "";
        public string TeacherId { get; set; } = "";
    }
}