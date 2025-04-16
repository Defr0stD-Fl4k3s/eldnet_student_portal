using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.DATA;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace StudentPortal.Web.Controllers
{
    public class SubjectPreqController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<SubjectPreqController> _logger;

        // Constructor with logger for debugging purposes
        public SubjectPreqController(ApplicationDbContext dbContext, ILogger<SubjectPreqController> logger)
        {
            this.dbContext = dbContext;
            _logger = logger;
        }

        // GET: Add Subject Preq Form
        [HttpGet]
        public IActionResult AddSubjectPreq()
        {
            // Clear any previous ModelState errors
            ModelState.Clear();
            return View(new AddSubjectPreqViewModel());
        }

        // POST: Add Subject Preq (Form Submission)
        [HttpPost]
        public async Task<IActionResult> Add(AddSubjectPreqViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddSubjectPreq", viewModel);
            }

            try
            {
                var subjectPreq = new SubjectPreqFile
                {
                    SUBJCODE = viewModel.SUBJCODE,
                    SUBJPRECODE = viewModel.SUBJPRECODE,
                    SUBJCATEGORY = viewModel.SUBJCATEGORY
                };

                await dbContext.SubjectPreqFiles.AddAsync(subjectPreq);
                await dbContext.SaveChangesAsync();

                _logger.LogInformation("Added new Subject Pre-requisite: {SubjCode} - {SubjPreCode}", subjectPreq.SUBJCODE, subjectPreq.SUBJPRECODE);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding Subject Pre-requisite.");
                return View("Error");  // Custom error page (optional)
            }

            return RedirectToAction("List");
        }

        // GET: List all subject prerequisites
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var list = await dbContext.SubjectPreqFiles
                .OrderBy(x => x.SUBJCODE)
                .ToListAsync();

            return View(list);
        }

        // GET: Edit Subject Preq
        [HttpGet]
        public async Task<IActionResult> Edit(string subjcode, string subjprecode)
        {
            var subject = await dbContext.SubjectPreqFiles
                .FirstOrDefaultAsync(x => x.SUBJCODE == subjcode && x.SUBJPRECODE == subjprecode);

            if (subject == null)
            {
                _logger.LogWarning("Subject Pre-requisite not found for {SubjCode} - {SubjPreCode}", subjcode, subjprecode);
                return NotFound();
            }

            var viewModel = new AddSubjectPreqViewModel
            {
                SUBJCODE = subject.SUBJCODE,
                SUBJPRECODE = subject.SUBJPRECODE,
                SUBJCATEGORY = subject.SUBJCATEGORY
            };

            return View(viewModel);
        }

        // POST: Edit Subject Preq
        [HttpPost]
        public async Task<IActionResult> Edit(AddSubjectPreqViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var subject = await dbContext.SubjectPreqFiles
                .FirstOrDefaultAsync(x => x.SUBJCODE == viewModel.SUBJCODE && x.SUBJPRECODE == viewModel.SUBJPRECODE);

            if (subject == null)
            {
                _logger.LogWarning("Subject Pre-requisite not found for {SubjCode} - {SubjPreCode}", viewModel.SUBJCODE, viewModel.SUBJPRECODE);
                return NotFound();
            }

            subject.SUBJCATEGORY = viewModel.SUBJCATEGORY;

            try
            {
                await dbContext.SaveChangesAsync();
                _logger.LogInformation("Updated Subject Pre-requisite: {SubjCode} - {SubjPreCode}", subject.SUBJCODE, subject.SUBJPRECODE);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Subject Pre-requisite.");
                return View("Error");  // Custom error page (optional)
            }

            return RedirectToAction("List");
        }

        // POST: Delete Subject Preq
        [HttpPost]
        public async Task<IActionResult> Delete(string subjcode, string subjprecode)
        {
            var subject = await dbContext.SubjectPreqFiles
                .FirstOrDefaultAsync(x => x.SUBJCODE == subjcode && x.SUBJPRECODE == subjprecode);

            if (subject == null)
            {
                _logger.LogWarning("Subject Pre-requisite not found for {SubjCode} - {SubjPreCode}", subjcode, subjprecode);
                return NotFound();
            }

            try
            {
                dbContext.SubjectPreqFiles.Remove(subject);
                await dbContext.SaveChangesAsync();
                _logger.LogInformation("Deleted Subject Pre-requisite: {SubjCode} - {SubjPreCode}", subjcode, subjprecode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting Subject Pre-requisite.");
                return View("Error");  // Custom error page (optional)
            }

            return RedirectToAction("List");
        }
    }
}
