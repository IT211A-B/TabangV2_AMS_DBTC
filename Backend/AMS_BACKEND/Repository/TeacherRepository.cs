using AMS_BACKEND.ApplicationDBContext;
using AMS_BACKEND.DTO;
using AMS_BACKEND.Interfaces;
using AMS_BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace AMS_BACKEND.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDBContext _context;

        public TeacherRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseTeacherDTO>> GetAll()
        {
            return await _context.Teachers
                .Select(t => new ResponseTeacherDTO
                {
                    TeacherId = t.TeacherId,
                    FullName = t.FullName,
                    Email = t.Email
                }).ToListAsync();
        }

        public async Task<ResponseTeacherDTO?> GetById(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return null;

            return new ResponseTeacherDTO
            {
                TeacherId = teacher.TeacherId,
                FullName = teacher.FullName,
                Email = teacher.Email
            };
        }

        public async Task<ResponseTeacherDTO> Create(CreateTeacherDTO dto)
        {
            var teacher = new Teacher
            {
                FullName = dto.FullName,
                Email = dto.Email
            };

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return new ResponseTeacherDTO
            {
                TeacherId = teacher.TeacherId,
                FullName = teacher.FullName,
                Email = teacher.Email
            };
        }

        public async Task<ResponseTeacherDTO?> Update(int id, UpdateTeacherDTO dto)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return null;

            teacher.FullName = dto.FullName;
            teacher.Email = dto.Email;

            await _context.SaveChangesAsync();

            return new ResponseTeacherDTO
            {
                TeacherId = teacher.TeacherId,
                FullName = teacher.FullName,
                Email = teacher.Email
            };
        }

        public async Task<bool> Delete(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return false;

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}