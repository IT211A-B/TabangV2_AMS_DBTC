namespace AMS_BACKEND.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Sex { get; set; } = "";
        public string Coursehandled { get; set; } = "";
        public string Status { get; set; } = ""; // Active / Inactive
    }
}