using AMS_BACKEND.DTO;
using AMS_BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_BACKEND.Controllers
{
    [ApiController]
    [Route("api/attendance")]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceService _service;
        public AttendanceController(AttendanceService service) { _service = service; }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAttendanceDTO dto)
        {
            var created = await _service.Create(dto);
            return Ok(created);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAttendanceDTO dto)
        {
            var updated = await _service.Update(dto);
            if (updated == null) return NotFound("Attendance record not found.");
            return Ok(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string studentId, [FromQuery] string courseId, [FromQuery] DateTime date)
        {
            var deleted = await _service.Delete(studentId, courseId, date);
            if (!deleted) return NotFound("Attendance record not found.");
            return NoContent();
        }
    }
}