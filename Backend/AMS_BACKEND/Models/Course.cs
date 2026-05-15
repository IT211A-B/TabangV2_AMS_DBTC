namespace AMS_BACKEND.Models
{
    public class Course
    {
        public required string CourseCode { get; set; } // IT210
        public string CourseName { get; set; } = ""; // Information Technology
        public string Department { get; set; } = ""; // College of Computer Studies
        public string Units { get; set; } = ""; // 3
        public string TeacherId { get; set; } = ""; // 101 (foreign key to Teacher)
    }
}