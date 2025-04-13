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
            Console.WriteLine("Form submitted!");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid. Student not saved.");

                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Field: {state.Key}, Error: {error.ErrorMessage}");
                    }
                }

                return View(viewModel);
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

            Console.WriteLine("About to add student:");
            Console.WriteLine($"{studentfile.STFSTUDFNAME} {studentfile.STFSTUDLNAME}");

            await dbContext.StudentFiles.AddAsync(studentfile);

            try
            {
                var result = await dbContext.SaveChangesAsync();
                Console.WriteLine($"Saved {result} records to database");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving: {ex.Message}");
            }

            return RedirectToAction("List");
        }

        // GET: List of Students
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var studentfile = await dbContext.StudentFiles.OrderBy(s => s.STFSTUDLNAME).ToListAsync();

            Console.WriteLine($"Retrieved {studentfile.Count} students:");
            foreach (var student in studentfile)
            {
                Console.WriteLine($"- {student.STFSTUDFNAME} {student.STFSTUDLNAME}, Status: {student.STFSTUDSTATUS}, Remarks: {student.STFSTUDREMARKS}");
            }

            return View(studentfile);
        }

        // GET: Edit Student Form
        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var studentfile = await dbContext.StudentFiles.FindAsync(id);

            if (studentfile == null)
            {
                return NotFound();
            }

            var viewModel = new AddStudentViewModel
            {
                STFSTUDID = studentfile.STFSTUDID,
                STFSTUDLNAME = studentfile.STFSTUDLNAME,
                STFSTUDFNAME = studentfile.STFSTUDFNAME,
                STFSTUDMNAME = studentfile.STFSTUDMNAME,
                STFSTUDCOURSE = studentfile.STFSTUDCOURSE,
                STFSTUDYEAR = studentfile.STFSTUDYEAR,
                STFSTUDREMARKS = studentfile.STFSTUDREMARKS,
                STFSTUDSTATUS = studentfile.STFSTUDSTATUS
            };

            return View(viewModel);
        }

        // POST: Edit Student
        [HttpPost]
        public async Task<IActionResult> Edit(AddStudentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var studentfile = await dbContext.StudentFiles.FindAsync(viewModel.STFSTUDID);

            if (studentfile is not null)
            {
                studentfile.STFSTUDLNAME = viewModel.STFSTUDLNAME;
                studentfile.STFSTUDFNAME = viewModel.STFSTUDFNAME;
                studentfile.STFSTUDMNAME = viewModel.STFSTUDMNAME;
                studentfile.STFSTUDCOURSE = viewModel.STFSTUDCOURSE;
                studentfile.STFSTUDYEAR = viewModel.STFSTUDYEAR;
                studentfile.STFSTUDREMARKS = viewModel.STFSTUDREMARKS;
                studentfile.STFSTUDSTATUS = viewModel.STFSTUDSTATUS;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Students");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(StudentFile viewModel)  
        {
            var studentfile = await dbContext.StudentFiles.FindAsync(viewModel.STFSTUDID);

            if (studentfile is not null)
            {
                dbContext.StudentFiles.Remove(studentfile);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");

        }
    }
}
