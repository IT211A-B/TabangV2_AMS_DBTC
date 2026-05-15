using AMS_BACKEND.DTO;
using AMS_BACKEND.Interfaces;

namespace AMS_BACKEND.Services
{
    public class StudentService(IStudentRepository repo)
    {
        public Task<List<ResponseStudentDTO>> GetAll() => repo.GetAll();
        public Task<ResponseStudentDTO?> GetById(int id) => repo.GetById(id);
        public Task<ResponseStudentDTO> Create(CreateStudentDTO dto) => repo.Create(dto);
        public Task<ResponseStudentDTO?> Update(int id, UpdateStudentDTO dto) => repo.Update(id, dto);
        public Task<bool> Delete(int id) => repo.Delete(id);
    }

    public class TeacherService(ITeacherRepository repo)
    {
        public Task<List<ResponseTeacherDTO>> GetAll() => repo.GetAll();
        public Task<ResponseTeacherDTO?> GetById(int id) => repo.GetById(id);
        public Task<ResponseTeacherDTO> Create(CreateTeacherDTO dto) => repo.Create(dto);
        public Task<ResponseTeacherDTO?> Update(int id, UpdateTeacherDTO dto) => repo.Update(id, dto);
        public Task<bool> Delete(int id) => repo.Delete(id);
    }

    public class CourseService(ICourseRepository repo)
    {
        public Task<List<ResponseCourseDTO>> GetAll() => repo.GetAll();
        public Task<ResponseCourseDTO?> GetById(int id) => repo.GetById(id);
        public Task<ResponseCourseDTO> Create(CreateCourseDTO dto) => repo.Create(dto);
        public Task<ResponseCourseDTO?> Update(int id, UpdateCourseDTO dto) => repo.Update(id, dto);
        public Task<bool> Delete(int id) => repo.Delete(id);
    }

    public class AttendanceService(IAttendanceRepository repo)
    {
        public Task<List<ResponseAttendanceDTO>> GetAll() => repo.GetAll();
        public Task<ResponseAttendanceDTO> Create(CreateAttendanceDTO dto) => repo.Create(dto);
        public Task<ResponseAttendanceDTO?> Update(UpdateAttendanceDTO dto) => repo.Update(dto);
        public Task<bool> Delete(string sId, string cId, DateTime date) => repo.Delete(sId, cId, date);

        internal async Task<bool> Delete(string studentId, int courseCode, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}