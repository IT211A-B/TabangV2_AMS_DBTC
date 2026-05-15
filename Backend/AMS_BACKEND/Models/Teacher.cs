namespace AMS_BACKEND.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; } // 103
        public string FullName { get; set; } = ""; // Jane Smith
        public string Email { get; set; } = "";
        public string Sex { get; set; } = ""; // Male, Female, Other
        public string Coursehandled { get; set; } = ""; // Information Technology, Computer Science, etc.
        public string Status { get; set; } = ""; // Active / Inactive
    }
}