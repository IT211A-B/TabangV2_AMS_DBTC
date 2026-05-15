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

        //GET ALL TEACHERS
        [HttpGet]
        public IActionResult GetAll()
        {
            var teachers = _teacherService.GetAll();
            return Json(teachers);
        }

        //GET TEACHER BY ID
        [HttpGet]
        public IActionResult Get(int id)
        {
            var teacher = _teacherService.Get(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Json(teacher);
        }
        //CREATE TEACHER
        [HttpPost]
        public IActionResult Create([FromBody] TeacherModel teacher)
        {
            var created = _teacherService.Create(teacher);
            return Json(new { success = true, data = created });
        }
        //EDIT TEACHER
        [HttpPost]
        public IActionResult Edit([FromBody] TeacherModel teacher)
        {
            var updated = _teacherService.Edit(teacher);
            if (updated == null)
            {
                return NotFound(new { success = false });
            }
            return Json(new { success = true });
        }

        //DELETE TEACHER
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _teacherService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return Json(new { success = true });
        }
    }
}
