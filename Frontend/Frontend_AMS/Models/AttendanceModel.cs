using System.Globalization;

namespace Frontend_AMS.Models
{
    public class AttendanceModel
    {
        public int StudentsId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }  
        public string Status { get; set; } = "Present"; //Present,On Leave,Absent
        public string Remarks { get; set; } 
        public StudentModel Students { get; set; }
    }
}
