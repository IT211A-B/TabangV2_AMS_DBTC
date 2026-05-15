using Frontend_AMS.Models;
using Frontend_AMS.Services;
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
        public IActionResult Create([FromBody] AttendanceModel attendance)
        {
            var created = true;// Implement logic to create a new attendance record ako ra ni ge tab maam 
            return View();
        }

        //EDIT ATTENDANCE RECORD
        [HttpPut]
        public IActionResult Edit([FromBody] AttendanceModel attendance)
        {
            var edited = true;// Implement logic to create a new attendance record ako ra ni ge tab maam 
            return View();
        }

        //DELETE ATTENDANCE RECORD
        [HttpDelete]
        public IActionResult Delete()
        {
            var deleted = true;// Implement logic to create a new attendance record ako ra ni ge tab maam
            return View();
        }
    }
}
