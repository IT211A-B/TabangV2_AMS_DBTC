using AMS_BACKEND.ApplicationDBContext;
using AMS_BACKEND.DTO;
using AMS_BACKEND.Interfaces;
using AMS_BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace AMS_BACKEND.Repositories
{  
    public class AttendanceRepository(AppDBContext context) : IAttendanceRepository
    {
        public async Task<List<ResponseAttendanceDTO>> GetAll() =>
            await context.Attendances
                .Select(a => new ResponseAttendanceDTO(
                    a.StudentId, a.CourseId, a.TeacherId,
                    a.Status, a.Remarks, a.Date))
                .ToListAsync();

        public async Task<ResponseAttendanceDTO> Create(CreateAttendanceDTO dto)
        {
            var a = new Attendance
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                TeacherId = dto.TeacherId,
                Status = dto.Status,
                Remarks = dto.Remarks,
                Date = dto.Date,
                CreatedAt = DateTime.UtcNow
            };
            context.Attendances.Add(a);
            await context.SaveChangesAsync();
            return new ResponseAttendanceDTO(
                a.StudentId, a.CourseId, a.TeacherId,
                a.Status, a.Remarks, a.Date);
        }

        public async Task<ResponseAttendanceDTO?> Update(UpdateAttendanceDTO dto)
        {
            var a = await context.Attendances
                .FirstOrDefaultAsync(a => a.StudentId == dto.StudentId
                                       && a.CourseId == dto.CourseId
                                       && a.Date == dto.Date);
            if (a == null) return null;
            a.TeacherId = dto.TeacherId;
            a.Status = dto.Status;
            a.Remarks = dto.Remarks;
            a.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return new ResponseAttendanceDTO(
                a.StudentId, a.CourseId, a.TeacherId,
                a.Status, a.Remarks, a.Date);
        }

        public async Task<bool> Delete(string studentId, string courseId, DateTime date)
        {
            var a = await context.Attendances
                .FirstOrDefaultAsync(a => a.StudentId == studentId
                                       && a.CourseId == courseId
                                       && a.Date == date);
            if (a == null) return false;
            context.Attendances.Remove(a);
            await context.SaveChangesAsync();
            return true;
        }
    }
}