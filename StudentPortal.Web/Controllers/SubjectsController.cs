using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.DATA;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;
using System.Threading.Tasks;
using System.Linq;

namespace StudentPortal.Web.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public SubjectsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Add Subject Form
        [HttpGet]
        public IActionResult AddSubjects()
        {
            ModelState.Clear();
            return View(new AddSubjectsViewModel());
        }

        // POST: Add Subject (Form Submission)
        [HttpPost]
        public async Task<IActionResult> Add(AddSubjectsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var subjectFile = new SubjectFile
            {
                SFSUBJCODE = viewModel.SFSUBJCODE,
                SFSUBJDESC = viewModel.SFSUBJDESC,
                SFSUBJUNITS = viewModel.SFSUBJUNITS,
                SFSUBJREGOFRNG = viewModel.SFSUBJREGOFRNG,
                SFSUBJCATEGORY = viewModel.SFSUBJCATEGORY,
                SFSUBJSTATUS = viewModel.SFSUBJSTATUS,
                SFSUBJCOURSECODE = viewModel.SFSUBJCOURSECODE,
                SFSUBJCURRCODE = viewModel.SFSUBJCURRCODE
            };

            await dbContext.SubjectFiles.AddAsync(subjectFile);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }

        // GET: List of Subjects
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var subjectList = await dbContext.SubjectFiles
                .OrderBy(s => s.SFSUBJDESC)
                .ToListAsync();

            return View(subjectList);
        }

        // GET: Edit Subject
        [HttpGet]
        public async Task<IActionResult> Edit(string id, string course)
        {
            var subject = await dbContext.SubjectFiles
                .FirstOrDefaultAsync(s => s.SFSUBJCODE == id && s.SFSUBJCOURSECODE == course);

            if (subject == null)
            {
                return NotFound();
            }

            var viewModel = new AddSubjectsViewModel
            {
                SFSUBJCODE = subject.SFSUBJCODE,
                SFSUBJDESC = subject.SFSUBJDESC,
                SFSUBJUNITS = subject.SFSUBJUNITS,
                SFSUBJREGOFRNG = subject.SFSUBJREGOFRNG,
                SFSUBJCATEGORY = subject.SFSUBJCATEGORY,
                SFSUBJSTATUS = subject.SFSUBJSTATUS,
                SFSUBJCOURSECODE = subject.SFSUBJCOURSECODE,
                SFSUBJCURRCODE = subject.SFSUBJCURRCODE
            };

            return View(viewModel);
        }

        // POST: Edit Subject
        [HttpPost]
        public async Task<IActionResult> Edit(AddSubjectsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var subject = await dbContext.SubjectFiles
                .FirstOrDefaultAsync(s => s.SFSUBJCODE == viewModel.SFSUBJCODE && s.SFSUBJCOURSECODE == viewModel.SFSUBJCOURSECODE);

            if (subject != null)
            {
                subject.SFSUBJDESC = viewModel.SFSUBJDESC;
                subject.SFSUBJUNITS = viewModel.SFSUBJUNITS;
                subject.SFSUBJREGOFRNG = viewModel.SFSUBJREGOFRNG;
                subject.SFSUBJCATEGORY = viewModel.SFSUBJCATEGORY;
                subject.SFSUBJSTATUS = viewModel.SFSUBJSTATUS;
                subject.SFSUBJCURRCODE = viewModel.SFSUBJCURRCODE;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }

        // POST: Delete Subject
        [HttpPost]
        public async Task<IActionResult> Delete(string SFSUBJCODE, string SFSUBJCOURSECODE)
        {
            var subject = await dbContext.SubjectFiles
                .FirstOrDefaultAsync(s => s.SFSUBJCODE == SFSUBJCODE && s.SFSUBJCOURSECODE == SFSUBJCOURSECODE);

            if (subject != null)
            {
                dbContext.SubjectFiles.Remove(subject);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }
    }
}
