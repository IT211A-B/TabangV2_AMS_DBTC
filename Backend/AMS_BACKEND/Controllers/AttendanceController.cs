// ============================================================
//  ATTENDANCE CONTROLLER  –  handles HTTP requests for /api/attendance
//  No GetById – records are looked up by StudentId + CourseId + Date.
// ============================================================

using AMS_BACKEND.DTO;
using AMS_BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_BACKEND.Controllers
{
    /// <summary>Log and manage student attendance records.</summary>
    [ApiController]
    [Route("api/attendance")]
    [Produces("application/json")]
    public class AttendanceController(AttendanceService service) : ControllerBase
    {
        /// <summary>Get all attendance records.</summary>
        /// <response code="200">List of attendance records.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseAttendanceDTO>), 200)]
        public async Task<IActionResult> GetAll() => Ok(await service.GetAll());

        /// <summary>Log a new attendance entry.</summary>
        /// <response code="200">Attendance recorded.</response>
        /// <response code="400">Validation error.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseAttendanceDTO), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateAttendanceDTO dto)
        {
            var created = await service.Create(dto);
            return Ok(created);
        }

        /// <summary>Update an attendance entry (matched by StudentId + CourseId + Date).</summary>
        /// <response code="200">Attendance updated.</response>
        /// <response code="400">Validation error.</response>
        /// <response code="404">Record not found.</response>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseAttendanceDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] UpdateAttendanceDTO dto)
        {
            var updated = await service.Update(dto);
            return updated == null ? NotFound("Attendance record not found.") : Ok(updated);
        }

        /// <summary>Delete an attendance entry.</summary>
        /// <param name="studentId">Student ID</param>
        /// <param name="courseId">Course ID</param>
        /// <param name="date">Date (e.g. 2025-01-15)</param>
        /// <response code="204">Deleted successfully.</response>
        /// <response code="404">Record not found.</response>
        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(
            [FromQuery] string studentId,
            [FromQuery] string courseId,
            [FromQuery] DateTime date)
        {
            var deleted = await service.Delete(studentId, courseId, date);
            return deleted ? NoContent() : NotFound("Attendance record not found.");
        }
    }
}