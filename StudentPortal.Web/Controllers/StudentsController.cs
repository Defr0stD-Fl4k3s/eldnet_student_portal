using Microsoft.AspNetCore.Mvc;
using StudentPortal.Web.DATA;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;
using System.Threading.Tasks;

namespace StudentPortal.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddStudentViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Log ModelState errors
                foreach (var error in ModelState)
                {
                    foreach (var subError in error.Value.Errors)
                    {
                        Console.WriteLine($"Field: {error.Key}, Error: {subError.ErrorMessage}");
                    }
                }
                return View(viewModel); // Return form with validation errors
            }

            var studentfile = new StudentFile
            {
                STFSTUDLNAME = viewModel.STFSTUDLNAME.Trim(),
                STFSTUDFNAME = viewModel.STFSTUDFNAME.Trim(),
                STFSTUDMNAME = viewModel.STFSTUDMNAME?.Trim(),
                STFSTUDCOURSE = viewModel.STFSTUDCOURSE.Trim(),
                STFSTUDYEAR = viewModel.STFSTUDYEAR,
                STFSTUDSTATUS = viewModel.STFSTUDSTATUS,
                STFSTUDREMARKS = viewModel.STFSTUDREMARKS
            };

            await dbContext.StudentFiles.AddAsync(studentfile);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
