using Microsoft.AspNetCore.Mvc;

namespace Frontend_AMS.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Courses";
            ViewData["ActivePage"] = "Courses";
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
