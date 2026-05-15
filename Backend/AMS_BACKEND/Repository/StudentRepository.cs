using AMS_BACKEND.ApplicationDBContext;
using AMS_BACKEND.DTO;
using AMS_BACKEND.Interfaces;
using AMS_BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace AMS_BACKEND.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDBContext _context;

        public StudentRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseStudentDTO>> GetAll()
        {
            return await _context.Students
                .Select(s => new ResponseStudentDTO
                {
                    StudentId = s.StudentId,
                    FullName = s.FullName,
                    Email = s.Email,
                    Age = s.Age
                }).ToListAsync();
        }

        public async Task<ResponseStudentDTO?> GetById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return null;

            return new ResponseStudentDTO
            {
                StudentId = student.StudentId,
                FullName = student.FullName,
                Email = student.Email,
                Age = student.Age
            };
        }

        public async Task<ResponseStudentDTO> Create(CreateStudentDTO dto)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Age = dto.Age
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return new ResponseStudentDTO
            {
                StudentId = student.StudentId,
                FullName = student.FullName,
                Email = student.Email,
                Age = student.Age
            };
        }

        public async Task<ResponseStudentDTO?> Update(int id, UpdateStudentDTO dto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return null;

            student.FullName = dto.FullName;
            student.Email = dto.Email;
            student.Age = dto.Age;

            await _context.SaveChangesAsync();

            return new ResponseStudentDTO
            {
                StudentId = student.StudentId,
                FullName = student.FullName,
                Email = student.Email,
                Age = student.Age
            };
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}