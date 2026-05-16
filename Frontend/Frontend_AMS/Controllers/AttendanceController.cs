using Frontend_AMS.Models;
using Frontend_AMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace Frontend_AMS.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly AttendanceService _attendanceService;

        public AttendanceController(AttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        //renders Index
        public IActionResult Index()
        {
            ViewData["Title"] = "Attendance";
            ViewData["ActivePage"] = "Attendance";
            return View();
        }

        // GetAll
        [HttpGet]
        public IActionResult GetAll()
        {
            var records = _attendanceService.GetAll();
            return Json(records);
        }

        // GetById
        [HttpGet]
        public IActionResult Get(int id)
        {
            var record = _attendanceService.Get(id);
            if (record == null)
                return NotFound(new { success = false });

            return Json(record);
        }

        // Create
        [HttpPost]
        public IActionResult Create([FromBody] AttendanceModel attendance)
        {
            var created = _attendanceService.Create(attendance);
            return Ok(new { success = true, data = created }); 
        }

        //Edit
        [HttpPut]
        public IActionResult Edit([FromBody] AttendanceModel attendance)
        {
            var updated = _attendanceService.Edit(attendance);
            if (updated == null)
                return NotFound(new { success = false });

            return Ok(new { success = true, data = updated }); 
        }

        // Delete
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deleted = _attendanceService.Delete(id);
            if (!deleted)
                return NotFound(new { success = false });

            return Ok(new { success = true }); 
        }
    }
}
