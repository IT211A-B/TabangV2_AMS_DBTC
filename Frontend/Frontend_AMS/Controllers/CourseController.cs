using Microsoft.AspNetCore.Mvc;
using Frontend_AMS.Models;
using Frontend_AMS.Services;

namespace Frontend_AMS.Controllers
{
    public class CourseController : Controller
    {
        private readonly Services.CourseService _courseService;
        public CourseController(Services.CourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Courses";
            ViewData["ActivePage"] = "Courses";
            return View();
        }

        //GET ALL COURSES
        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = _courseService.GetAll();
            return Json(courses);
        }


        //GET COURSE BY ID
        [HttpGet]
        public IActionResult Get(string courseCode)
        {
            var course = _courseService.Get(courseCode);
            if (course == null)
            {
                return NotFound();
            }
            return Json(course);
        }

        //CREATE COURSE
        [HttpPost]
        public IActionResult Create([FromBody] CourseModel course)
        {
            var created = _courseService.Create(course);
            return View();
        }

        //EDIT COURSE
        [HttpPut]
         public IActionResult Edit([FromBody] CourseModel course)
        {
            var updated = _courseService.Edit(course);
            if (updated == null)
                return NotFound(new { success = false });

            return Ok(new { success = true, data = updated });
        }

        //DELETE COURSE
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
