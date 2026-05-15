using AMS_BACKEND.DTO;
using AMS_BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_BACKEND.Controllers
{
    /// <summary>Handles course records.</summary>
    [ApiController, Route("api/courses"), Produces("application/json")]
    public class CourseController(CourseService service) : ControllerBase
    {
        /// <summary>Returns all courses.</summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseCourseDTO>), 200)]
        public async Task<IActionResult> GetAll() => Ok(await service.GetAll());

        /// <summary>Returns a course by Code.</summary>
        [HttpGet("{code}")]
        [ProducesResponseType(typeof(ResponseCourseDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int code)
        {
            var course = await service.GetById(code);
            return course == null ? NotFound("Course not found.") : Ok(course);
        }

        /// <summary>Creates a new course.</summary>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCourseDTO), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateCourseDTO dto)
        {
            var created = await service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.CourseId }, created);
        }

        /// <summary>Updates an existing course by Code.</summary>
        [HttpPut("{code}")]
        [ProducesResponseType(typeof(ResponseCourseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int code, [FromBody] UpdateCourseDTO dto)
        {
            var updated = await service.Update(code, dto);
            return updated == null ? NotFound("Course not found.") : Ok(updated);
        }

        /// <summary>Deletes a course by Code.</summary>
        [HttpDelete("{code}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int code)
        {
            var deleted = await service.Delete(code);
            return deleted ? NoContent() : NotFound("Course not found.");
        }
    }
}