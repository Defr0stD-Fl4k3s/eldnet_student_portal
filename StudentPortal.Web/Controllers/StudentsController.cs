using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: Add Student Form
        [HttpGet]
        public IActionResult Add()
        {
            ModelState.Clear(); // Clear validation errors on form load
            return View(new AddStudentViewModel()); // Pass empty model
        }

        // POST: Add Student (Form Submission)
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
               
                return View(viewModel); // Return form with validation errors
            }

            var studentfile = new StudentFile   
            {
                STFSTUDLNAME = viewModel.STFSTUDLNAME,
                STFSTUDFNAME = viewModel.STFSTUDFNAME,
                STFSTUDMNAME = viewModel.STFSTUDMNAME,
                STFSTUDCOURSE = viewModel.STFSTUDCOURSE,
                STFSTUDYEAR = viewModel.STFSTUDYEAR,
                STFSTUDSTATUS = viewModel.STFSTUDSTATUS,
                STFSTUDREMARKS = viewModel.STFSTUDREMARKS
            };

            await dbContext.StudentFiles.AddAsync(studentfile);

            Console.WriteLine("Attempting to save student record...");

            var result = await dbContext.SaveChangesAsync();     

            Console.WriteLine($"Saved {result} records to database"); // Should output 1 if successful


            return RedirectToAction("List");
        }

        // GET: List of Students
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var studentfile = await dbContext.StudentFiles.OrderBy(s => s.STFSTUDLNAME).ToListAsync();

            Console.WriteLine($"Retrieved {studentfile.Count} students"); // Debug output

            return View(studentfile);
        }
    }
}
