using Frontend_AMS.Models;

namespace Frontend_AMS.Services
{
    public class StudentService
    {
        private static List<StudentModel> _students = new List<StudentModel>
        {
            new StudentModel { }

        };
        private static int _nextId = 1;

        //GET ALL STUDENTS
        public List<StudentModel> GetAll()
        {
            return _students;

        }

        //GET BY ID
        public StudentModel Get(int id) {
            return _students.FirstOrDefault(s => s.StudentsId == id);
        }

        //ADD STUDENT
        public StudentModel Create(StudentModel student)
        {
            student.StudentsId = _nextId++;
            _students.Add(student);
            return student;
        }

        //EDIT STUDENT
        public StudentModel Edit(StudentModel student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.StudentsId == student.StudentsId);
            if (existingStudent != null)
            {
                existingStudent.FullName = student.FullName;
                existingStudent.Email = student.Email;
                existingStudent.Status = student.Status;
                existingStudent.Course = student.Course;
                existingStudent.YearLevel = student.YearLevel;
            }
            return existingStudent;
        }

        //DELETE STUDENT
        public bool Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentsId == id);
            if (student != null)
            {
                _students.Remove(student);
                return true;
            }
            return false;
        }
    }
}
