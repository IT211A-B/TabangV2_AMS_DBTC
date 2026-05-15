namespace Frontend_AMS.Models
{
    public class CourseModel
    {
        public string CourseCode { get; set; } = "IT21"; // e.g., IT201,CS101 AND MANY MORE
        public string Department { get; set; } = "Computer Science"; // "Computer Science"
        public string CourseName { get; set; } = "Introduction to IT";// e.g., "Introduction to IT"
        public string TeacherID { get; set; } = "John Doe"; // e.g., "John Doe"
        public int Units { get; set; } = 3; // e.g., 3
    }
}
