using Microsoft.AspNetCore.Mvc;
using Frontend_AMS.Models;
using Frontend_AMS.Services;

namespace Frontend_AMS.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }
        //renders Index
        public IActionResult Index()
        {
            ViewData["Title"] = "Courses";
            ViewData["ActivePage"] = "Courses";
            return View();
        }

        //GetAll
        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = _courseService.GetAll();
            return Json(courses);
        }

        // GETbyID
        [HttpGet]
        public IActionResult Get(string courseCode)
        {
            var course = _courseService.Get(courseCode);
            if (course == null)
                return NotFound(new { success = false });

            return Json(course);
        }

        // Create
        [HttpPost]
        public IActionResult Create([FromBody] CourseModel course)
        {
            var created = _courseService.Create(course);
            return Ok(new { success = true, data = created }); 
        }

        // Edit
        [HttpPut]
        public IActionResult Edit([FromBody] CourseModel course)
        {
            var updated = _courseService.Edit(course);
            if (updated == null)
                return NotFound(new { success = false });

            return Ok(new { success = true, data = updated });
        }

        // Delete
        [HttpDelete]
        public IActionResult Delete(string courseCode)
        {
            var deleted = _courseService.Delete(courseCode);
            if (!deleted)
                return NotFound(new { success = false });

            return Ok(new { success = true });
        }
    }
}
