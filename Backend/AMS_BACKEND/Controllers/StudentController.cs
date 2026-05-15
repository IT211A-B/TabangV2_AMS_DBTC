using AMS_BACKEND.DTO;
using AMS_BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_BACKEND.Controllers
{
    [ApiController, Route("api/students"), Produces("application/json")]
    public class StudentController(StudentService service) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseStudentDTO>), 200)]
        public async Task<IActionResult> GetAll() => Ok(await service.GetAll());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseStudentDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await service.GetById(id);
            return student == null ? NotFound("Student not found.") : Ok(student);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseStudentDTO), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateStudentDTO dto)
        {
            var created = await service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.StudentId }, created);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseStudentDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentDTO dto)
        {
            var updated = await service.Update(id, dto);
            return updated == null ? NotFound("Student not found.") : Ok(updated);
        }

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