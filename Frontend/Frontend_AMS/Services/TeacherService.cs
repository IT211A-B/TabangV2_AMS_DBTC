using Frontend_AMS.Models;

namespace Frontend_AMS.Services
{
    public class TeacherService
    {
        private static List<TeacherModel> _teachers = new List<TeacherModel>
        {
            new TeacherModel { }
        };
        private static int _nextId = 1;
   
        //GET ALL TEACHERS
        public List<TeacherModel> GetAll()
        {
            return _teachers;
        }

        //GET BY ID
        public TeacherModel Get(int id)
        {
            return _teachers.FirstOrDefault(t => t.TeacherId == id);
        }

        //ADD TEACHER
        public TeacherModel Create(TeacherModel teacher)
        {
            teacher.TeacherId = _nextId++;
            _teachers.Add(teacher);
            return teacher;
        }

        //EDIT TEACHER
        public TeacherModel Edit(TeacherModel teacher)
        {
            var existingTeacher = _teachers.FirstOrDefault(t => t.TeacherId == teacher.TeacherId);
            if (existingTeacher != null)
            {
                existingTeacher.FullName = teacher.FullName;
                existingTeacher.Email = teacher.Email;
                existingTeacher.Status = teacher.Status;
                existingTeacher.Department = teacher.Department;
                existingTeacher.CourseCode = teacher.CourseCode;
            }
            return existingTeacher;
        }

        //DELETE TEACHER
        public bool Delete(int id)
        {
            var teacher = _teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacher != null)
            {
                _teachers.Remove(teacher);
                return true;
            }
            return false;
        }
    }
}
