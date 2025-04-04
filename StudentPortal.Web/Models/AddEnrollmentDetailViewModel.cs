using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    [PrimaryKey(nameof(ENRDFSTUDID), nameof(ENRDFSTUDEDPCODE))]

    public class AddEnrollmentDetailViewModel
    {
        public long ENRDFSTUDID { get; set; } // Student ID

        public string ENRDFSTUDEDPCODE { get; set; } // Department Code

        [StringLength(15)]
        public string ENRDFSTUDSUBJCDE { get; set; } // Subject Code

        [StringLength(2)]
        [RegularExpression("WD|CA", ErrorMessage = "Must be 'WD' (Withdrawn) or 'CA' (Cancelled).")]
        public string ENRDFSTUDSTATUS { get; set; }
    }
}
