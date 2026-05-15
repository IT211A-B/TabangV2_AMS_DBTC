using AMS_BACKEND.DTO;

namespace AMS_BACKEND.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<ResponseStudentDTO>> GetAll();
        Task<ResponseStudentDTO?> GetById(int id);
        Task<ResponseStudentDTO> Create(CreateStudentDTO dto);
        Task<ResponseStudentDTO?> Update(int id, UpdateStudentDTO dto);
        Task<bool> Delete(int id);
    }

    public interface ITeacherRepository
    {
        Task<List<ResponseTeacherDTO>> GetAll();
        Task<ResponseTeacherDTO?> GetById(int id);
        Task<ResponseTeacherDTO> Create(CreateTeacherDTO dto);
        Task<ResponseTeacherDTO?> Update(int id, UpdateTeacherDTO dto);
        Task<bool> Delete(int id);
    }

    public interface ICourseRepository
    {
        Task<List<ResponseCourseDTO>> GetAll();
        Task<ResponseCourseDTO?> GetById(int id);
        Task<ResponseCourseDTO> Create(CreateCourseDTO dto);
        Task<ResponseCourseDTO?> Update(int id, UpdateCourseDTO dto);
        Task<bool> Delete(int id);
    }

    public interface IAttendanceRepository
    {
        Task<List<ResponseAttendanceDTO>> GetAll();
        Task<ResponseAttendanceDTO> Create(CreateAttendanceDTO dto);
        Task<ResponseAttendanceDTO?> Update(UpdateAttendanceDTO dto);
        Task<bool> Delete(string studentId, string courseId, DateTime date);
    }
}