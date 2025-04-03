using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Web.Controllers
{
    public class SubjectSchedController : Controller
    {
        [HttpGet]
        public IActionResult AddSubjectSched()
        {
            return View();
        }
    }
}
