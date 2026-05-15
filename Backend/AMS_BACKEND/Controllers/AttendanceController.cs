using AMS_BACKEND.DTO;
using AMS_BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_BACKEND.Controllers
{
    /// <summary>Handles attendance records.</summary>
    [ApiController, Route("api/attendance"), Produces("application/json")]
    public class AttendanceController(AttendanceService service) : ControllerBase
    {
        /// <summary>Returns all attendance records.</summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseAttendanceDTO>), 200)]
        public async Task<IActionResult> GetAll() => Ok(await service.GetAll());

        /// <summary>Logs a new attendance entry.</summary>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseAttendanceDTO), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateAttendanceDTO dto)
        {
            var created = await service.Create(dto);
            return StatusCode(201, created);
        }

        /// <summary>Updates an attendance entry matched by StudentId, CourseId, and Date.</summary>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseAttendanceDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] UpdateAttendanceDTO dto)
        {
            var updated = await service.Update(dto);
            return updated == null ? NotFound("Attendance record not found.") : Ok(updated);
        }

        /// <summary>Deletes an attendance entry by StudentId, CourseCode, and Date.</summary>
        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(
            [FromQuery] string studentId,
            [FromQuery] int courseCode,
            [FromQuery] DateTime date)
        {
            var deleted = await service.Delete(studentId, courseCode, date);
            return deleted ? NoContent() : NotFound("Attendance record not found.");
        }
    }
}