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
