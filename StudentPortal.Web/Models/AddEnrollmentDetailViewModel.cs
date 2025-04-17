using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    [PrimaryKey(nameof(ENRDFSTUDID), nameof(ENRDFSTUDEDPCODE))]
    public class AddEnrollmentDetailViewModel
    {
        [Required(ErrorMessage = "Student ID is required.")]
        public long ENRDFSTUDID { get; set; } // Student ID

        [Required(ErrorMessage = "EDP Code is required.")]
        [StringLength(8, ErrorMessage = "EDP Code must be at most 8 characters.")]
        public string ENRDFSTUDEDPCODE { get; set; } // Department Code

        [StringLength(15, ErrorMessage = "Subject Code must be at most 15 characters.")]
        public string ENRDFSTUDSUBJCDE { get; set; } // Subject Code

        [StringLength(2)]
        [RegularExpression("WD|CA", ErrorMessage = "Must be 'WD' (Withdrawn) or 'CA' (Cancelled).")]
        public string ENRDFSTUDSTATUS { get; set; }
    }
}
