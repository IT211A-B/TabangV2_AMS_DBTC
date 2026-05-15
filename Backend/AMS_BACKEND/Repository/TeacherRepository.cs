using AMS_BACKEND.ApplicationDBContext;
using AMS_BACKEND.DTO;
using AMS_BACKEND.Interfaces;
using AMS_BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace AMS_BACKEND.Repositories
{
    public class TeacherRepository(AppDBContext context) : ITeacherRepository
    {
        public async Task<List<ResponseTeacherDTO>> GetAll() =>
            await context.Teachers
                .Select(t => new ResponseTeacherDTO(
                    t.TeacherId, 
                    t.FullName, 
                    t.Email,
                    t.Sex, 
                    t.Coursehandled, 
                    t.Status))
                .ToListAsync();

        public async Task<ResponseTeacherDTO?> GetById(int id)
        {
            var t = await context.Teachers.FindAsync(id);
            return t == null ? null : new ResponseTeacherDTO(
                t.TeacherId, 
                t.FullName, 
                t.Email,
                t.Sex, 
                t.Coursehandled, 
                t.Status);
        }

        public async Task<ResponseTeacherDTO> Create(CreateTeacherDTO dto)
        {
            var t = new Teacher
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Sex = dto.Sex,
                Coursehandled = dto.Coursehandled,
                Status = dto.Status
            };
            context.Teachers.Add(t);
            await context.SaveChangesAsync();
            return new ResponseTeacherDTO(
                t.TeacherId, t.FullName, t.Email,
                t.Sex, t.Coursehandled, t.Status);
        }

        public async Task<ResponseTeacherDTO?> Update(int id, UpdateTeacherDTO dto)
        {
            var t = await context.Teachers.FindAsync(id);
            if (t == null) return null;
            t.FullName = dto.FullName; t.Email = dto.Email;
            t.Sex = dto.Sex; t.Coursehandled = dto.Coursehandled;
            t.Status = dto.Status;
            await context.SaveChangesAsync();
            return new ResponseTeacherDTO(
                t.TeacherId, t.FullName, t.Email,
                t.Sex, t.Coursehandled, t.Status);
        }

        public async Task<bool> Delete(int id)
        {
            var t = await context.Teachers.FindAsync(id);
            if (t == null) return false;
            context.Teachers.Remove(t);
            await context.SaveChangesAsync();
            return true;
        }
    }
}