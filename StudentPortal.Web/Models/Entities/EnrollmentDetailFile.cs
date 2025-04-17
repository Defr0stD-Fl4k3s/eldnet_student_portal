using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Web.Models.Entities
{
    [PrimaryKey(nameof(ENRDFSTUDID), nameof(ENRDFSTUDEDPCODE))]

    public class EnrollmentDetailFile
    {
        public long ENRDFSTUDID { get; set; } // Student ID

        [StringLength(8)]
        public string ENRDFSTUDEDPCODE { get; set; } // Department Code

        [StringLength(15)]
        public string ENRDFSTUDSUBJCDE { get; set; } // Subject Code

        [StringLength(2)]
        [RegularExpression("WD|CA", ErrorMessage = "Must be 'WD' (Withdrawn) or 'CA' (Cancelled).")]
        public string ENRDFSTUDSTATUS { get; set; }
    }

}
