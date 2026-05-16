using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS_BACKEND.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // manual input
        public long StudentId { get; set; }  // 11988623231
        public string FullName { get; set; } = ""; // John Doe
        public string Email { get; set; } = ""; 
        public string Age { get; set; } = ""; // 18
        public string Sex { get; set; } = "";   // Male / Female / Other
        public string Course { get; set; } = ""; 
        public string YearLevel { get; set; } = "";   // 1st Year to 4th Year
        public string Status { get; set; } = "";   // Active / Inactive / Dropped
    }
}
