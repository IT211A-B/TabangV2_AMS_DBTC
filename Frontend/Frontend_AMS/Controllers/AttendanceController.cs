using Microsoft.AspNetCore.Mvc;

namespace Frontend_AMS.Controllers
{
    public class AttendanceController : Controller
    {
        public IActionResult Index()
        {
                ViewData["Title"] = "Attendance";
                ViewData["ActivePage"] = "Attendance";

            return View();
        }
        //GET ALL ATTENDANCE RECORDS
        [HttpGet]
        public IActionResult GetAll()
        {
            // Implement logic to retrieve all attendance records
            return Json(new { success = true, data = new List<object>() });
        }

        //GET ATTENDANCE RECORD BY ID
        [HttpGet]
        public IActionResult Get(int id)
        {
            // Implement logic to retrieve an attendance record by ID
            return Json(new { success = true, data = new { Id = id } });
        }

        //CREATE ATTENDANCE RECORD
        [HttpPost]
        public IActionResult Create()
        {

            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
