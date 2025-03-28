using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Web.Controllers
{
    public class SubjectsController : Controller
    {
        [HttpGet]
        public IActionResult AddSubjects()
        {
            return View();
        }
    }
}
