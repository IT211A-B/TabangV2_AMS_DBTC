using AMS_BACKEND.DTO;
using AMS_BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_BACKEND.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherService _service;
        public TeacherController(TeacherService service) { _service = service; }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _service.GetById(id);
            if (teacher == null) return NotFound("Teacher not found.");
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTeacherDTO dto)
        {
            var created = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.TeacherId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTeacherDTO dto)
        {
            var updated = await _service.Update(id, dto);
            if (updated == null) return NotFound("Teacher not found.");
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.Delete(id);
            if (!deleted) return NotFound("Teacher not found.");
            return NoContent();
        }
    }
}