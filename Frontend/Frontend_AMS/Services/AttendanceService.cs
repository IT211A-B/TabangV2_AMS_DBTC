using Frontend_AMS.Models;

namespace Frontend_AMS.Services
{
    public class AttendanceService
    {
        private static List<AttendanceModel> _attendances = new List<AttendanceModel>
        {
            new AttendanceModel { }
        };
        private static int _nextId = 1;
        
        //GET ALL ATTENDANCES
        public List<AttendanceModel> GetAll()
        {
            return _attendances;
        }

        //GET BY ID
        public AttendanceModel Get(int id)
        {
            return _attendances.FirstOrDefault(a => a.StudentsId == id);
        }

        //ADD ATTENDANCE
        public AttendanceModel Create(AttendanceModel attendance)
        {
            attendance.StudentsId = _nextId++;
            _attendances.Add(attendance);
            return attendance;
        }

        //EDIT ATTENDANCE
        public AttendanceModel Edit(AttendanceModel attendance)
        {
            var existingAttendance = _attendances.FirstOrDefault(a => a.StudentsId == attendance.StudentsId);
            if (existingAttendance != null)
            {
                existingAttendance.FullName = attendance.FullName;
                existingAttendance.Date = attendance.Date;
                existingAttendance.Status = attendance.Status;
                existingAttendance.Remarks = attendance.Remarks;
                existingAttendance.Students = attendance.Students;
            }
            return existingAttendance;
        }

        //DELETE ATTENDANCE
        public bool Delete(int id)
        {
            var attendance = _attendances.FirstOrDefault(a => a.StudentsId == id);
            if (attendance != null)
            {
                _attendances.Remove(attendance);
                return true;
            }
            return false;
        }   
    }
}
