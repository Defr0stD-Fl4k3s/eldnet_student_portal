﻿using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.DATA
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<StudentFile> StudentFiles { get; set; }
        public DbSet<SubjectFile> SubjectFiles { get; set; }

        public DbSet<SubjectPreqFile> SubjectPreqFiles { get; set; }

        public DbSet<SubjectSchedFile> SubjectSchedFiles { get; set; }

        public DbSet<EnrollmentHeaderFile> EnrollmentHeaderFiles { get; set; }

        public DbSet<EnrollmentDetailFile> EnrollmentDetailFile { get; set; }

        public DbSet<StudentGradeFile> StudentGradeFiles { get; set; }
    }
}
