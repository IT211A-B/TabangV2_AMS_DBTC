namespace Frontend_AMS.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public string Status { get; set; } = "Present"; //Present,Absent,On Leave
    }
}
