namespace AMS_BACKEND.Models
{
    public class Attendance
    {
        public string StudentId { get; set; } = "";
        public string CourseId { get; set; } = "";
        public string TeacherId { get; set; } = "";
        public string Status { get; set; } = ""; // Present / Absent / Late / Excused
        public string Remarks { get; set; } = "";
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}