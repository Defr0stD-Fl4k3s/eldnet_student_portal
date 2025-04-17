using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.DATA;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class StudentGradeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentGradeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // LIST
        public async Task<IActionResult> List()
        {
            var grades = await _dbContext.StudentGradeFiles.ToListAsync();
            return View(grades);
        }

        // ADD - GET
        [HttpGet]
        public IActionResult AddStudentGrade()
        {
            return View();
        }

        // ADD - POST
        [HttpPost]
        public async Task<IActionResult> AddStudentGrade(AddStudentGradeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var gradeEntity = new StudentGradeFile
            {
                SGFSTUDID = model.SGFSTUDID,
                SGFSTUDSUBJCODE = model.SGFSTUDSUBJCODE,
                SGFSTUDSUBJGRADE = model.SGFSTUDSUBJGRADE,
                SGFSTUDEDPCODE = model.SGFSTUDEDPCODE,
                SGFSTUDREMARKS = model.SGFSTUDREMARKS
            };

            _dbContext.StudentGradeFiles.Add(gradeEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }

        // EDIT - GET
        [HttpGet]
        public async Task<IActionResult> Edit(long id, string deptCode, string subjCode)
        {
            var entity = await _dbContext.StudentGradeFiles.FindAsync(id, deptCode, subjCode);
            if (entity == null)
            {
                return NotFound();
            }

            var model = new AddStudentGradeViewModel
            {
                SGFSTUDID = entity.SGFSTUDID,
                SGFSTUDSUBJCODE = entity.SGFSTUDSUBJCODE,
                SGFSTUDSUBJGRADE = entity.SGFSTUDSUBJGRADE,
                SGFSTUDEDPCODE = entity.SGFSTUDEDPCODE,
                SGFSTUDREMARKS = entity.SGFSTUDREMARKS
            };

            return View(model); // Passing the AddStudentGradeViewModel to the view
        }

        // EDIT - POST
        [HttpPost]
        public async Task<IActionResult> Edit(AddStudentGradeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = await _dbContext.StudentGradeFiles.FindAsync(model.SGFSTUDID, model.SGFSTUDEDPCODE, model.SGFSTUDSUBJCODE);
            if (entity == null)
            {
                return NotFound();
            }

            entity.SGFSTUDSUBJGRADE = model.SGFSTUDSUBJGRADE;
            entity.SGFSTUDREMARKS = model.SGFSTUDREMARKS;

            await _dbContext.SaveChangesAsync();
            return RedirectToAction("List");
        }

        // DELETE - GET
        [HttpGet]
        public async Task<IActionResult> Delete(long id, string deptCode, string subjCode)
        {
            var entity = await _dbContext.StudentGradeFiles.FindAsync(id, deptCode, subjCode);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // DELETE - POST
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long id, string deptCode, string subjCode)
        {
            var entity = await _dbContext.StudentGradeFiles.FindAsync(id, deptCode, subjCode);
            if (entity == null)
            {
                return NotFound();
            }

            _dbContext.StudentGradeFiles.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }
    }
}
