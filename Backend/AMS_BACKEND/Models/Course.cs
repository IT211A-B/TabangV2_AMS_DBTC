namespace AMS_BACKEND.Models
{
    public class Course
    {
        public required string CourseCode { get; set; } = string.Empty; // IT210
        public string CourseName { get; set; } = string.Empty; // Information Technology
        public string Department { get; set; } = string.Empty; // College of Computer Studies
        public string Units { get; set; } = string.Empty; // 3
        public string TeacherId { get; set; } = string.Empty; // 101 
    }
}