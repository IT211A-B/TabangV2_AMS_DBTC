namespace Frontend_AMS.Models
{
    public class StudentModel
    {
        public int StudentsId { get; set; }
        public string Name { get; set; } = string.Empty;// Initialize with an empty string to avoid null reference issues
        public string Email { get; set; }
        public string Status { get; set; } = "Present"; //Present,Absent,Late,Excused
        public string Course { get; set; } = "BSIT"; //BSIT,BSME,BTVETED
        public int YearLevel { get; set; }
    }
}
