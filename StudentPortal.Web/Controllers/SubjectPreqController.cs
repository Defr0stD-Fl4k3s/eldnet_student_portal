using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Web.Controllers
{
    public class SubjectPreqController : Controller
    {
        [HttpGet]
        public IActionResult AddSubjectPreq()
        {
            return View();
        }
    }
}
