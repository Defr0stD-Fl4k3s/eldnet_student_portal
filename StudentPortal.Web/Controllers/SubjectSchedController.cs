using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.DATA;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Web.Controllers
{
    public class SubjectSchedController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public SubjectSchedController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Add Subject Schedule Form
        [HttpGet]
        public IActionResult AddSubjectSched()
        {
            ModelState.Clear();
            return View(new AddSubjectSchedViewModel());
        }

        // POST: Add Subject Schedule
        [HttpPost]
        public async Task<IActionResult> Add(AddSubjectSchedViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddSubjectSched", viewModel);
            }

            var sched = new SubjectSchedFile
            {
                SSFEDPCODE = viewModel.SSFEDPCODE,
                SSFSUBJCODE = viewModel.SSFSUBJCODE,
                SSFSTARTTIME = viewModel.SSFSTARTTIME,
                SSFENDTIME = viewModel.SSFENDTIME,
                SSFDAYS = viewModel.SSFDAYS,
                SSFROOM = viewModel.SSFROOM,
                SSFMAXSIZE = viewModel.SSFMAXSIZE,
                SSFCLASSSIZE = viewModel.SSFCLASSSIZE,
                SSFSTATUS = viewModel.SSFSTATUS,
                SSFXM = viewModel.SSFXM,
                SSFSECTION = viewModel.SSFSECTION,
                SSFSCHOOLYEAR = viewModel.SSFSCHOOLYEAR
            };

            await dbContext.SubjectSchedFiles.AddAsync(sched);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }

        // GET: List Subject Schedules
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var schedList = await dbContext.SubjectSchedFiles
                .OrderBy(s => s.SSFSUBJCODE)
                .ToListAsync();

            return View(schedList);
        }

        // GET: Edit Subject Schedule
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var sched = await dbContext.SubjectSchedFiles
                .FirstOrDefaultAsync(s => s.SSFEDPCODE == id);

            if (sched == null)
            {
                return NotFound();
            }

            var viewModel = new AddSubjectSchedViewModel
            {
                SSFEDPCODE = sched.SSFEDPCODE,
                SSFSUBJCODE = sched.SSFSUBJCODE,
                SSFSTARTTIME = sched.SSFSTARTTIME,
                SSFENDTIME = sched.SSFENDTIME,
                SSFDAYS = sched.SSFDAYS,
                SSFROOM = sched.SSFROOM,
                SSFMAXSIZE = sched.SSFMAXSIZE,
                SSFCLASSSIZE = sched.SSFCLASSSIZE,
                SSFSTATUS = sched.SSFSTATUS,
                SSFXM = sched.SSFXM,
                SSFSECTION = sched.SSFSECTION,
                SSFSCHOOLYEAR = sched.SSFSCHOOLYEAR
            };

            return View(viewModel);
        }

        // POST: Edit Subject Schedule
        [HttpPost]
        public async Task<IActionResult> Edit(AddSubjectSchedViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var sched = await dbContext.SubjectSchedFiles
                .FirstOrDefaultAsync(s => s.SSFEDPCODE == viewModel.SSFEDPCODE && s.SSFSUBJCODE == viewModel.SSFSUBJCODE);

            if (sched != null)
            {
                sched.SSFSTARTTIME = viewModel.SSFSTARTTIME;
                sched.SSFENDTIME = viewModel.SSFENDTIME;
                sched.SSFDAYS = viewModel.SSFDAYS;
                sched.SSFROOM = viewModel.SSFROOM;
                sched.SSFMAXSIZE = viewModel.SSFMAXSIZE;
                sched.SSFCLASSSIZE = viewModel.SSFCLASSSIZE;
                sched.SSFSTATUS = viewModel.SSFSTATUS;
                sched.SSFXM = viewModel.SSFXM;
                sched.SSFSECTION = viewModel.SSFSECTION;
                sched.SSFSCHOOLYEAR = viewModel.SSFSCHOOLYEAR;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }

        // POST: Delete Subject Schedule
        [HttpPost]
        public async Task<IActionResult> Delete(string SSFEDPCODE, string SSFSUBJCODE)
        {
            var sched = await dbContext.SubjectSchedFiles
                .FirstOrDefaultAsync(s => s.SSFEDPCODE == SSFEDPCODE && s.SSFSUBJCODE == SSFSUBJCODE);

            if (sched != null)
            {
                dbContext.SubjectSchedFiles.Remove(sched);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }
    }
}
