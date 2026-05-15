using Frontend_AMS.Models;
using System.Runtime.CompilerServices;

namespace Frontend_AMS.Services
{
    public class CourseService
    {
        private static List<CourseModel> _courses = new List<CourseModel>
        {
            new CourseModel { CourseCode = "IT21", CourseName = "Introduction to IT", Department = "Computer Science", TeacherID = "John Doe", Units = 3 },
            new CourseModel { CourseCode = "CS10", CourseName = "Introduction to Computer Science", Department = "Computer Science", TeacherID = "Jane Smith", Units = 4 },
        };

        //GET ALL COURSES
        public List<CourseModel> GetAll()
        {
            return _courses;
        }

        //GET BY ID
        public CourseModel Get(string courseCode)
        {
            return _courses.FirstOrDefault(c => c.CourseCode == courseCode);
        }

        //ADD COURSE
        public CourseModel Create(CourseModel course)
        {
            _courses.Add(course);
            return course;
        }

        //EDIT COURSE
        public CourseModel Edit(CourseModel course)
        {
            var existingCourse = _courses.FirstOrDefault(c => c.CourseCode == course.CourseCode);
            if (existingCourse != null)
            {
                existingCourse.Department = course.Department;
                existingCourse.CourseCode = course.CourseCode;
                existingCourse.CourseName = course.CourseName;
                existingCourse.TeacherID = course.TeacherID;
                existingCourse.Units = course.Units;
            }
            return existingCourse;
        }

        //DELETE COURSE
        public bool Delete(string courseCode)
        {
            var course = _courses.FirstOrDefault(c => c.CourseCode == courseCode);
            if (course != null)
            {
                _courses.Remove(course);
                return true;
            }
            return false;
        }

    }
}
