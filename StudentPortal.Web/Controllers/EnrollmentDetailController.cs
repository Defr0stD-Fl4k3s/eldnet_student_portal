using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.DATA;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;
using System.Threading.Tasks;

namespace StudentPortal.Web.Controllers
{
    public class EnrollmentDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EnrollmentDetail/List
        public async Task<IActionResult> List()
        {
            var enrollmentDetails = await _context.EnrollmentDetailFile.ToListAsync();
            return View(enrollmentDetails);
        }

        // GET: EnrollmentDetail/AddEnrollmentDetail
        public IActionResult AddEnrollmentDetail()
        {
            return View();
        }

        // POST: EnrollmentDetail/AddEnrollmentDetail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEnrollmentDetail(AddEnrollmentDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var enrollmentDetail = new EnrollmentDetailFile
                {
                    ENRDFSTUDID = model.ENRDFSTUDID,               // Student ID
                    ENRDFSTUDEDPCODE = model.ENRDFSTUDEDPCODE,     // EDP Code
                    ENRDFSTUDSUBJCDE = model.ENRDFSTUDSUBJCDE,     // Subject Code
                    ENRDFSTUDSTATUS = model.ENRDFSTUDSTATUS        // Status
                };

                _context.EnrollmentDetailFile.Add(enrollmentDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }

            return View(model);
        }

        // GET: EnrollmentDetail/Edit/{studentId}/{edpCode}
        public async Task<IActionResult> Edit(long studentId, string edpCode)
        {
            var enrollmentDetail = await _context.EnrollmentDetailFile
                .FirstOrDefaultAsync(e => e.ENRDFSTUDID == studentId && e.ENRDFSTUDEDPCODE == edpCode);

            if (enrollmentDetail == null)
                return NotFound();

            var model = new AddEnrollmentDetailViewModel
            {
                ENRDFSTUDID = enrollmentDetail.ENRDFSTUDID,
                ENRDFSTUDEDPCODE = enrollmentDetail.ENRDFSTUDEDPCODE,
                ENRDFSTUDSUBJCDE = enrollmentDetail.ENRDFSTUDSUBJCDE,
                ENRDFSTUDSTATUS = enrollmentDetail.ENRDFSTUDSTATUS
            };

            return View(model);
        }

        // POST: EnrollmentDetail/Edit/{studentId}/{edpCode}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long studentId, string edpCode, AddEnrollmentDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var enrollmentDetail = await _context.EnrollmentDetailFile
                    .FirstOrDefaultAsync(e => e.ENRDFSTUDID == studentId && e.ENRDFSTUDEDPCODE == edpCode);

                if (enrollmentDetail == null)
                    return NotFound();

                enrollmentDetail.ENRDFSTUDID = model.ENRDFSTUDID;
                enrollmentDetail.ENRDFSTUDEDPCODE = model.ENRDFSTUDEDPCODE;
                enrollmentDetail.ENRDFSTUDSUBJCDE = model.ENRDFSTUDSUBJCDE;
                enrollmentDetail.ENRDFSTUDSTATUS = model.ENRDFSTUDSTATUS;

                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }

            return View(model);
        }

        // GET: EnrollmentDetail/Delete/{studentId}/{edpCode}
        public async Task<IActionResult> Delete(long studentId, string edpCode)
        {
            var enrollmentDetail = await _context.EnrollmentDetailFile
                .FirstOrDefaultAsync(e => e.ENRDFSTUDID == studentId && e.ENRDFSTUDEDPCODE == edpCode);

            if (enrollmentDetail == null)
                return NotFound();

            _context.EnrollmentDetailFile.Remove(enrollmentDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }
    }
}
