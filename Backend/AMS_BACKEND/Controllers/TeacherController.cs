using AMS_BACKEND.DTO;
using AMS_BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_BACKEND.Controllers
{
    [ApiController, Route("api/teachers"), Produces("application/json")]
    public class TeacherController(TeacherService service) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseTeacherDTO>), 200)]
        public async Task<IActionResult> GetAll() => Ok(await service.GetAll());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseTeacherDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await service.GetById(id);
            return teacher == null ? NotFound("Teacher not found.") : Ok(teacher);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseTeacherDTO), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateTeacherDTO dto)
        {
            var created = await service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.TeacherId }, created);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseTeacherDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTeacherDTO dto)
        {
            var updated = await service.Update(id, dto);
            return updated == null ? NotFound("Teacher not found.") : Ok(updated);
        }

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