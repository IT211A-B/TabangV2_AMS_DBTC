using AMS_BACKEND.DTO;
using AMS_BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_BACKEND.Controllers
{
    /// <summary>Create, read, update, and delete course records.</summary>
    [ApiController]
    [Route("api/courses")]
    [Produces("application/json")]
    public class CourseController(CourseService service) : ControllerBase
    {
        /// <summary>Get all courses.</summary>
        /// <response code="200">List of courses.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseCourseDTO>), 200)]
        public async Task<IActionResult> GetAll() => Ok(await service.GetAll());

        /// <summary>Get a single course by ID.</summary>
        /// <response code="200">Course found.</response>
        /// <response code="404">Course not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseCourseDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await service.GetById(id);
            return course == null ? NotFound("Course not found.") : Ok(course);
        }

        /// <summary>Add a new course.</summary>
        /// <response code="201">Course created.</response>
        /// <response code="400">Validation error.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCourseDTO), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateCourseDTO dto)
        {
            var created = await service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.CourseId }, created);
        }

        /// <summary>Update an existing course.</summary>
        /// <response code="200">Course updated.</response>
        /// <response code="400">Validation error.</response>
        /// <response code="404">Course not found.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseCourseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseDTO dto)
        {
            var updated = await service.Update(id, dto);
            return updated == null ? NotFound("Course not found.") : Ok(updated);
        }

        /// <summary>Delete a course.</summary>
        /// <response code="204">Deleted successfully.</response>
        /// <response code="404">Course not found.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.Delete(id);
            return deleted ? NoContent() : NotFound("Course not found.");
        }
    }
}