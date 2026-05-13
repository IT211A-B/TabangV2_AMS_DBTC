namespace AMS_BACKEND.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Age { get; set; } = "";
        public string Sex { get; set; } = "";   // Male / Female / Other
        public string Course { get; set; } = "";
        public string YearLevel { get; set; } = "";   // 1st Year to 4th Year
        public string Status { get; set; } = "";   // Active / Inactive / Dropped
    }
}