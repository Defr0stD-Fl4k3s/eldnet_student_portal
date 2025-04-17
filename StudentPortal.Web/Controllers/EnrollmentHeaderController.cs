using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.DATA;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Web.Controllers
{
    public class EnrollmentHeaderController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public EnrollmentHeaderController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Add Enrollment Header Form
        [HttpGet]
        public IActionResult AddEnrollmentHeader()
        {
            ModelState.Clear();
            return View(new AddEnrollmentHeaderViewModel());
        }

        // POST: Add Enrollment Header
        [HttpPost]
        public async Task<IActionResult> AddEnrollmentHeader(AddEnrollmentHeaderViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var enrollment = new EnrollmentHeaderFile
            {
                ENRHFSTUDDATEENROLL = viewModel.ENRHFSTUDDATEENROLL,
                ENRHFSTUDSCHLYR = viewModel.ENRHFSTUDSCHLYR,
                ENRHFSTUDENCODER = viewModel.ENRHFSTUDENCODER,
                ENRHFSTUDTOTALUNITS = viewModel.ENRHFSTUDTOTALUNITS,
                ENRHFSTUDSTATUS = viewModel.ENRHFSTUDSTATUS
            };

            await dbContext.EnrollmentHeaderFiles.AddAsync(enrollment);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }

        // GET: List Enrollment Headers
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var enrollmentList = await dbContext.EnrollmentHeaderFiles
                .OrderBy(e => e.ENRHFSTUDID)
                .ToListAsync();

            return View(enrollmentList);
        }

        // GET: Edit Enrollment Header
        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var enrollment = await dbContext.EnrollmentHeaderFiles
                .FirstOrDefaultAsync(e => e.ENRHFSTUDID == id);

            if (enrollment == null)
            {
                return NotFound();
            }

            var viewModel = new AddEnrollmentHeaderViewModel
            {
                ENRHFSTUDID = enrollment.ENRHFSTUDID,
                ENRHFSTUDDATEENROLL = enrollment.ENRHFSTUDDATEENROLL,
                ENRHFSTUDSCHLYR = enrollment.ENRHFSTUDSCHLYR,
                ENRHFSTUDENCODER = enrollment.ENRHFSTUDENCODER,
                ENRHFSTUDTOTALUNITS = enrollment.ENRHFSTUDTOTALUNITS,
                ENRHFSTUDSTATUS = enrollment.ENRHFSTUDSTATUS
            };

            return View(viewModel);
        }

        // POST: Edit Enrollment Header
        [HttpPost]
        public async Task<IActionResult> Edit(AddEnrollmentHeaderViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var enrollment = await dbContext.EnrollmentHeaderFiles
                .FirstOrDefaultAsync(e => e.ENRHFSTUDID == viewModel.ENRHFSTUDID);

            if (enrollment != null)
            {
                enrollment.ENRHFSTUDDATEENROLL = viewModel.ENRHFSTUDDATEENROLL;
                enrollment.ENRHFSTUDSCHLYR = viewModel.ENRHFSTUDSCHLYR;
                enrollment.ENRHFSTUDENCODER = viewModel.ENRHFSTUDENCODER;
                enrollment.ENRHFSTUDTOTALUNITS = viewModel.ENRHFSTUDTOTALUNITS;
                enrollment.ENRHFSTUDSTATUS = viewModel.ENRHFSTUDSTATUS;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }

        // POST: Delete Enrollment Header
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var enrollment = await dbContext.EnrollmentHeaderFiles
                .FirstOrDefaultAsync(e => e.ENRHFSTUDID == id);

            if (enrollment != null)
            {
                dbContext.EnrollmentHeaderFiles.Remove(enrollment);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }
    }
}
