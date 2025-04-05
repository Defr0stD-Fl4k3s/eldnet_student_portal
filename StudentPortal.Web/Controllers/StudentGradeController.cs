using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Web.Controllers
{
    public class StudentGradeController : Controller
    {
        public IActionResult AddStudentGrade()
        {
            return View();
        }
    }
}
