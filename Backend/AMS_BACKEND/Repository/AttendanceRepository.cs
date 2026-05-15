using AMS_BACKEND.ApplicationDBContext;
using AMS_BACKEND.DTO;
using AMS_BACKEND.Interfaces;
using AMS_BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace AMS_BACKEND.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDBContext _context;

        public AttendanceRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseAttendanceDTO>> GetAll()
        {
            return await _context.Attendances
                .Select(a => new ResponseAttendanceDTO
                {
                    StudentId = a.StudentId,
                    CourseId = a.CourseId,
                    TeacherId = a.TeacherId,
                    Status = a.Status,
                    Remarks = a.Remarks,
                    Date = a.Date
                }).ToListAsync();
        }

        public async Task<ResponseAttendanceDTO> Create(CreateAttendanceDTO dto)
        {
            var attendance = new Attendance
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                TeacherId = dto.TeacherId,
                Status = dto.Status,
                Remarks = dto.Remarks,
                Date = dto.Date,
                CreatedAt = DateTime.UtcNow,
            };

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return new ResponseAttendanceDTO
            {
                StudentId = attendance.StudentId,
                CourseId = attendance.CourseId,
                TeacherId = attendance.TeacherId,
                Status = attendance.Status,
                Remarks = attendance.Remarks,
                Date = attendance.Date
            };
        }

        public async Task<ResponseAttendanceDTO?> Update(UpdateAttendanceDTO dto)
        {
            var attendance = await _context.Attendances
                .FirstOrDefaultAsync(a => a.StudentId == dto.StudentId
                                       && a.CourseId == dto.CourseId
                                       && a.Date == dto.Date);

            if (attendance == null) return null;

            attendance.TeacherId = dto.TeacherId;
            attendance.Status = dto.Status;
            attendance.Remarks = dto.Remarks;

            await _context.SaveChangesAsync();

            return new ResponseAttendanceDTO
            {
                StudentId = attendance.StudentId,
                CourseId = attendance.CourseId,
                TeacherId = attendance.TeacherId,
                Status = attendance.Status,
                Remarks = attendance.Remarks,
                Date = attendance.Date
            };
        }

        public async Task<bool> Delete(string studentId, string courseId, DateTime date)
        {
            var attendance = await _context.Attendances
                .FirstOrDefaultAsync(a => a.StudentId == studentId
                                       && a.CourseId == courseId
                                       && a.Date == date);

            if (attendance == null) return false;

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}