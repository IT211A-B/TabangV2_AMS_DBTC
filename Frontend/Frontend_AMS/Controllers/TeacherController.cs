using Microsoft.AspNetCore.Mvc;
using Frontend_AMS.Services;
using Frontend_AMS.Models;

namespace Frontend_AMS.Controllers
{
    public class TeacherController : Controller
    {
        private readonly TeacherService _teacherService;

        public TeacherController(TeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Teachers";
            ViewData["ActivePage"] = "Teachers";
            return View();
        }

        // GetAll
        [HttpGet]
        public IActionResult GetAll()
        {
            var teachers = _teacherService.GetAll();
            return Json(teachers);
        }

        // GetById
        [HttpGet]
        public IActionResult Get(int id)
        {
            var teacher = _teacherService.Get(id);
            if (teacher == null)
                return NotFound(new { success = false });

            return Json(teacher);
        }

        // Create
        [HttpPost]
        public IActionResult Create([FromBody] TeacherModel teacher)
        {
            var created = _teacherService.Create(teacher);
            return Ok(new { success = true, data = created });
        }

        // Edit 
        [HttpPut]
        public IActionResult Edit([FromBody] TeacherModel teacher)
        {
            var updated = _teacherService.Edit(teacher);
            if (updated == null)
                return NotFound(new { success = false });

            return Ok(new { success = true, data = updated });
        }

        // Delete
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _teacherService.Delete(id);
            if (!result)
                return NotFound(new { success = false });

            return Ok(new { success = true });
        }
    }
}
