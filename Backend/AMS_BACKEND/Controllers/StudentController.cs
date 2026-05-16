using AMS_BACKEND.DTO;
using AMS_BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_BACKEND.Controllers
{
    /// <summary>Handles student records.</summary>
    [ApiController, Route("api/students"), Produces("application/json")]
    public class StudentController(StudentService service) : ControllerBase
    {
        /// <summary>Returns all students.</summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseStudentDTO>), 200)]
        public async Task<IActionResult> GetAll() => Ok(await service.GetAll());

        /// <summary>Returns a student by ID.</summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseStudentDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(long id)
        {
            var student = await service.GetById(id);
            return student == null ? NotFound("Student not found.") : Ok(student);
        }

        /// <summary>Creates a new student. Status defaults to Active.</summary>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseStudentDTO), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateStudentDTO dto)
        {
            var created = await service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.StudentId }, created);
        }

        /// <summary>Updates an existing student by ID.</summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseStudentDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateStudentDTO dto)
        {
            var updated = await service.Update(id, dto);
            return updated == null ? NotFound("Student not found.") : Ok(updated);
        }

        /// <summary>Deletes a student by ID.</summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await service.Delete(id);
            return deleted ? NoContent() : NotFound("Student not found.");
        }
    }
}