namespace Frontend_AMS.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }= "BSIT"; // e.g., "BSIT"
        public string CourseName { get; set; } = "BS Information Technology";// e.g., "BS Information Technology"
        public string AssignedTeacher { get; set; } = "John Doe"; // e.g., "John Doe"
        public int units { get; set; } = 3; // e.g., 3

    }
}
