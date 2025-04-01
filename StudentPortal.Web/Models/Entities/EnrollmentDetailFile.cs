using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Web.Models.Entities
{
    public class EnrollmentDetailFile
    {
        [Key, Column(Order = 0)]
        public long ENRDFSTUDID { get; set; } // Student ID

        [Key, Column(Order = 1)]
        [StringLength(8)]
        public string ENRDFSTUDEDPCODE { get; set; } // Department Code

        [StringLength(15)]
        public string ENRDFSTUDSUBJCDE { get; set; } // Subject Code

        public EnrollmentDetailStatus ENRDFSTUDSTATUS { get; set; } // Status
    }
    public enum EnrollmentDetailStatus
    {
        Withdrawn,
        Cancelled
    }
}
