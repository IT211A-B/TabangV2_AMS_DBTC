using AMS_BACKEND.ApplicationDBContext;
using AMS_BACKEND.DTO;
using AMS_BACKEND.Interfaces;
using AMS_BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace AMS_BACKEND.Repositories
{
    public class CourseRepository(AppDBContext context) : ICourseRepository
    {
        public async Task<List<ResponseCourseDTO>> GetAll() =>
            await context.Courses
                .Select(c => new ResponseCourseDTO(
                    c.CourseId, c.CourseName,
                    c.Department, c.Units, c.TeacherId))
                .ToListAsync();

        public async Task<ResponseCourseDTO?> GetById(int id)
        {
            var c = await context.Courses.FindAsync(id);
            return c == null ? null : new ResponseCourseDTO(
                c.CourseId, c.CourseName,
                c.Department, c.Units, c.TeacherId);
        }

        public async Task<ResponseCourseDTO> Create(CreateCourseDTO dto)
        {
            var c = new Course
            {
                CourseName = dto.CourseName,
                Department = dto.Department,
                Units = dto.Units,
                TeacherId = dto.TeacherId
            };
            context.Courses.Add(c);
            await context.SaveChangesAsync();
            return new ResponseCourseDTO(
                c.CourseId, c.CourseName,
                c.Department, c.Units, c.TeacherId);
        }

        public async Task<ResponseCourseDTO?> Update(int id, UpdateCourseDTO dto)
        {
            var c = await context.Courses.FindAsync(id);
            if (c == null) return null;
            c.CourseName = dto.CourseName; c.Department = dto.Department;
            c.Units = dto.Units; c.TeacherId = dto.TeacherId;
            await context.SaveChangesAsync();
            return new ResponseCourseDTO(
                c.CourseId, c.CourseName,
                c.Department, c.Units, c.TeacherId);
        }

        public async Task<bool> Delete(int id)
        {
            var c = await context.Courses.FindAsync(id);
            if (c == null) return false;
            context.Courses.Remove(c);
            await context.SaveChangesAsync();
            return true;
        }
    }
}