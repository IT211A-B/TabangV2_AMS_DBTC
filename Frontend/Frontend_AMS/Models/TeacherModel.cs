namespace Frontend_AMS.Models
{
    public class TeacherModel
    {
        public int TeacherId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CourseCode { get; set; } = "IT210"; // IT210,CS101
        public string Status { get; set; } = "Present"; //Present,Absent,On Leave
        public string Department { get; set; } = "Computer Science"; // Computer Science, Mathematics
    }
}
