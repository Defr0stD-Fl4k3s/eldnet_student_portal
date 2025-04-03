using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Web.Controllers
{
    public class EnrollmentHeaderController : Controller
    {
        public IActionResult AddEnrollmentHeader()
        {
            return View();
        }
    }
}
