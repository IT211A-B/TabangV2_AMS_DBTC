namespace AMS_BACKEND.Models
{
    public class Attendance
    {
        public string StudentId { get; set; } = ""; // 11988612025
        public string CourseCode { get; set; } = ""; // IT210
        public string TeacherId { get; set; } = ""; //101
        public string Status { get; set; } = ""; // Present / Absent / Late / Excused
        public string Remarks { get; set; } = ""; // Comment
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}