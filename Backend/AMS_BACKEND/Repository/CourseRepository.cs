using AMS_BACKEND.ApplicationDBContext;
using AMS_BACKEND.DTO;
using AMS_BACKEND.Interfaces;
using AMS_BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace AMS_BACKEND.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDBContext _context;

        public CourseRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseCourseDTO>> GetAll()
        {
            return await _context.Courses
                .Select(c => new ResponseCourseDTO
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName,
                    Department = c.Department
                }).ToListAsync();
        }

        public async Task<ResponseCourseDTO?> GetById(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return null;

            return new ResponseCourseDTO
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                Department = course.Department
            };
        }

        public async Task<ResponseCourseDTO> Create(CreateCourseDTO dto)
        {
            var course = new Course
            {
                CourseName = dto.CourseName,
                Department = dto.Department
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return new ResponseCourseDTO
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                Department = course.Department
            };
        }

        public async Task<ResponseCourseDTO?> Update(int id, UpdateCourseDTO dto)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return null;

            course.CourseName = dto.CourseName;
            course.Department = dto.Department;

            await _context.SaveChangesAsync();

            return new ResponseCourseDTO
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                Department = course.Department
            };
        }

        public async Task<bool> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}