using AMS_BACKEND.DTO;
using AMS_BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_BACKEND.Controllers
{
    /// <summary>Create, read, update, and delete teacher records.</summary>
    [ApiController]
    [Route("api/teachers")]
    [Produces("application/json")]
    public class TeacherController(TeacherService service) : ControllerBase
    {
        /// <summary>Get all teachers.</summary>
        /// <response code="200">List of teachers.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseTeacherDTO>), 200)]
        public async Task<IActionResult> GetAll() => Ok(await service.GetAll());

        /// <summary>Get a single teacher by ID.</summary>
        /// <response code="200">Teacher found.</response>
        /// <response code="404">Teacher not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseTeacherDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await service.GetById(id);
            return teacher == null ? NotFound("Teacher not found.") : Ok(teacher);
        }

        /// <summary>Add a new teacher.</summary>
        /// <response code="201">Teacher created.</response>
        /// <response code="400">Validation error.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseTeacherDTO), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateTeacherDTO dto)
        {
            var created = await service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.TeacherId }, created);
        }

        /// <summary>Update an existing teacher.</summary>
        /// <response code="200">Teacher updated.</response>
        /// <response code="400">Validation error.</response>
        /// <response code="404">Teacher not found.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseTeacherDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTeacherDTO dto)
        {
            var updated = await service.Update(id, dto);
            return updated == null ? NotFound("Teacher not found.") : Ok(updated);
        }

        /// <summary>Delete a teacher.</summary>
        /// <response code="204">Deleted successfully.</response>
        /// <response code="404">Teacher not found.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.Delete(id);
            return deleted ? NoContent() : NotFound("Teacher not found.");
        }
    }
}