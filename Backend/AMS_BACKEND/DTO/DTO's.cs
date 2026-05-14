using System.ComponentModel.DataAnnotations;

namespace AMS_BACKEND.DTO
{
    //STUDENT

    public class CreateStudentDTO
    {
        [Required][StringLength(100)] public string FullName { get; set; } = "";
        [Required][EmailAddress] public string Email { get; set; } = "";
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Age must be a number.")]
        public string Age { get; set; } = "";
        [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Sex: Male, Female, or Other.")]
        public string Sex { get; set; } = "";
        [StringLength(100)] public string Course { get; set; } = "";
        [RegularExpression("^(1st Year|2nd Year|3rd Year|4th Year)$", ErrorMessage = "e.g. '1st Year'")]
        public string YearLevel { get; set; } = "";
        [RegularExpression("^(Active|Inactive|Dropped)$", ErrorMessage = "Active, Inactive, or Dropped.")]
        public string Status { get; set; } = "Active";
    }

    public class UpdateStudentDTO
    {
        [Required][StringLength(100)] public string FullName { get; set; } = "";
        [Required][EmailAddress] public string Email { get; set; } = "";
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Age must be a number.")]
        public string Age { get; set; } = "";
        [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Sex: Male, Female, or Other.")]
        public string Sex { get; set; } = "";
        [StringLength(100)] public string Course { get; set; } = "";
        [RegularExpression("^(1st Year|2nd Year|3rd Year|4th Year)$", ErrorMessage = "e.g. '1st Year'")]
        public string YearLevel { get; set; } = "";
        [RegularExpression("^(Active|Inactive|Dropped)$", ErrorMessage = "Active, Inactive, or Dropped.")]
        public string Status { get; set; } = "";
    }

    public class ResponseStudentDTO
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Age { get; set; } = "";
        public string Sex { get; set; } = "";
        public string Course { get; set; } = "";
        public string YearLevel { get; set; } = "";
        public string Status { get; set; } = "";
    }

    //TEACHER

    public class CreateTeacherDTO
    {
        [Required][StringLength(100)] public string FullName { get; set; } = "";
        [Required][EmailAddress] public string Email { get; set; } = "";
        [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Sex: Male, Female, or Other.")]
        public string Sex { get; set; } = "";
        [StringLength(200)] public string Coursehandled { get; set; } = "";
        [RegularExpression("^(Active|Inactive)$", ErrorMessage = "Active or Inactive.")]
        public string Status { get; set; } = "Active";
    }

    public class UpdateTeacherDTO
    {
        [Required][StringLength(100)] public string FullName { get; set; } = "";
        [Required][EmailAddress] public string Email { get; set; } = "";
        [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Sex: Male, Female, or Other.")]
        public string Sex { get; set; } = "";
        [StringLength(200)] public string Coursehandled { get; set; } = "";
        [RegularExpression("^(Active|Inactive)$", ErrorMessage = "Active or Inactive.")]
        public string Status { get; set; } = "";
    }

    public class ResponseTeacherDTO
    {
        public int TeacherId { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Sex { get; set; } = "";
        public string Coursehandled { get; set; } = "";
        public string Status { get; set; } = "";
    }

    //COURSE

    public class CreateCourseDTO
    {
        [Required][StringLength(100)] public string CourseName { get; set; } = "";
        [Required][StringLength(100)] public string Department { get; set; } = "";
        [RegularExpression(@"^\d+$", ErrorMessage = "Units must be a number.")]
        public string Units { get; set; } = "";
        public string TeacherId { get; set; } = "";
    }

    public class UpdateCourseDTO
    {
        [Required][StringLength(100)] public string CourseName { get; set; } = "";
        [Required][StringLength(100)] public string Department { get; set; } = "";
        [RegularExpression(@"^\d+$", ErrorMessage = "Units must be a number.")]
        public string Units { get; set; } = "";
        public string TeacherId { get; set; } = "";
    }

    public class ResponseCourseDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = "";
        public string Department { get; set; } = "";
        public string Units { get; set; } = "";
        public string TeacherId { get; set; } = "";
    }

    //ATTENDANCE

    public class CreateAttendanceDTO
    {
        [Required] public string StudentId { get; set; } = "";
        [Required] public string CourseId { get; set; } = "";
        [Required] public string TeacherId { get; set; } = "";
        [Required]
        [RegularExpression("^(Present|Absent|Late|Excused)$",
            ErrorMessage = "Status: Present, Absent, Late, or Excused.")]
        public string Status { get; set; } = "";
        [StringLength(500)] public string Remarks { get; set; } = "";
        [Required] public DateTime Date { get; set; }
    }

    public class UpdateAttendanceDTO
    {
        [Required] public string StudentId { get; set; } = "";
        [Required] public string CourseId { get; set; } = "";
        [Required] public string TeacherId { get; set; } = "";
        [Required]
        [RegularExpression("^(Present|Absent|Late|Excused)$",
            ErrorMessage = "Status: Present, Absent, Late, or Excused.")]
        public string Status { get; set; } = "";
        [StringLength(500)] public string Remarks { get; set; } = "";
        [Required] public DateTime Date { get; set; }
    }

    public class ResponseAttendanceDTO
    {
        public string StudentId { get; set; } = "";
        public string CourseId { get; set; } = "";
        public string TeacherId { get; set; } = "";
        public string Status { get; set; } = "";
        public string Remarks { get; set; } = "";
        public DateTime Date { get; set; }
    }
}