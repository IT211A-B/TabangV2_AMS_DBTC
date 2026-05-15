using Frontend_AMS.Models;
using Frontend_AMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace Frontend_AMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Students";
            ViewData["ActivePage"] = "Students";

            return View();
        }

        //GET ALL STUDENTS
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentService.GetAll();
            return Json(students);
        }

        //GET STUDENT BY ID
        [HttpGet]
        public IActionResult Get(int id)
        {
            var student = _studentService.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            return Json(student);
        }
        //CREATE STUDENT
        [HttpPost]
        public IActionResult Create([FromBody]StudentModel student)
        {
            var created = _studentService.Create(student);
            return View();
        }

        [HttpPut]
        //EDIT STUDENT
        public IActionResult Edit([FromBody]StudentModel student)
        {
            var updated = _studentService.Edit(student);
            if (updated == null)
                return NotFound(new { success = false });

            return Ok(new { success = true, data = updated });
        }

        //DELETE STUDENT
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deleted = _studentService.Delete(id);
            if (!deleted)
                return NotFound(new { success = false });

            return Ok(new { success = true });
        }
    }
}
