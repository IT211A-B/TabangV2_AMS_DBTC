using System.Globalization;

namespace Frontend_AMS.Models
{
    public class AttendanceModel
    {
        public int id { get; set; }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }  
        public string Status { get; set; }

        public StudentModel Students { get; set; }
    }
}
