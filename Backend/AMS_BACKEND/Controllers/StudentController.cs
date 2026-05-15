using AMS_BACKEND.DTO;
using AMS_BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_BACKEND.Controllers
{
    /// <summary>Create, read, update, and delete student records.</summary>
    [ApiController]
    [Route("api/students")]
    [Produces("application/json")]
    public class StudentController(StudentService service) : ControllerBase
    {
        /// <summary>Get all students.</summary>
        /// <response code="200">List of students.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseStudentDTO>), 200)]
        public async Task<IActionResult> GetAll() => Ok(await service.GetAll());

        /// <summary>Get a single student by ID.</summary>
        /// <response code="200">Student found.</response>
        /// <response code="404">Student not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseStudentDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await service.GetById(id);
            return student == null ? NotFound("Student not found.") : Ok(student);
        }

        /// <summary>Add a new student.</summary>
        /// <response code="201">Student created.</response>
        /// <response code="400">Validation error.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseStudentDTO), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateStudentDTO dto)
        {
            // ASP.NET checks the DTO annotations automatically.
            // If anything is invalid it returns 400 before we even get here.
            var created = await service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.StudentId }, created);
        }

        /// <summary>Update an existing student.</summary>
        /// <response code="200">Student updated.</response>
        /// <response code="400">Validation error.</response>
        /// <response code="404">Student not found.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseStudentDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentDTO dto)
        {
            var updated = await service.Update(id, dto);
            return updated == null ? NotFound("Student not found.") : Ok(updated);
        }

        /// <summary>Delete a student.</summary>
        /// <response code="204">Deleted successfully.</response>
        /// <response code="404">Student not found.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.Delete(id);
            return deleted ? NoContent() : NotFound("Student not found.");
        }
    }
}