using AMS_BACKEND.ApplicationDBContext;
using AMS_BACKEND.DTO;
using AMS_BACKEND.Interfaces;
using AMS_BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace AMS_BACKEND.Repositories
{
    public class StudentRepository(AppDBContext context) : IStudentRepository
    {
        public async Task<List<ResponseStudentDTO>> GetAll() =>
            await context.Students
                .Select(s => new ResponseStudentDTO(
                    s.StudentId, s.FullName, s.Email,
                    s.Age, s.Sex, s.Course,
                    s.YearLevel, s.Status))
                .ToListAsync();

        public async Task<ResponseStudentDTO?> GetById(long id)
        {
            var s = await context.Students.FindAsync(id);
            return s == null ? null : new ResponseStudentDTO(
                s.StudentId, s.FullName, s.Email,
                s.Age, s.Sex, s.Course,
                s.YearLevel, s.Status);
        }

        public async Task<ResponseStudentDTO> Create(CreateStudentDTO dto)
        {
            var s = new Student
            {
                StudentId = dto.StudentId, 
                FullName = dto.FullName,
                Email = dto.Email,
                Age = dto.Age,
                Sex = dto.Sex,
                Course = dto.Course,
                YearLevel = dto.YearLevel,
                Status = dto.Status
            };
            context.Students.Add(s);
            await context.SaveChangesAsync();
            return new ResponseStudentDTO(
                s.StudentId, s.FullName, s.Email,
                s.Age, s.Sex, s.Course,
                s.YearLevel, s.Status);
        }

        public async Task<ResponseStudentDTO?> Update(long id, UpdateStudentDTO dto) 
        {
            var s = await context.Students.FindAsync(id);
            if (s == null) return null;
            s.FullName = dto.FullName; s.Email = dto.Email;
            s.Age = dto.Age; s.Sex = dto.Sex;
            s.Course = dto.Course; s.YearLevel = dto.YearLevel;
            s.Status = dto.Status;
            await context.SaveChangesAsync();
            return new ResponseStudentDTO(
                s.StudentId, s.FullName, s.Email,
                s.Age, s.Sex, s.Course,
                s.YearLevel, s.Status);
        }

        public async Task<bool> Delete(long id) 
        {
            var s = await context.Students.FindAsync(id);
            if (s == null) return false;
            context.Students.Remove(s);
            await context.SaveChangesAsync();
            return true;
        }
    }
}