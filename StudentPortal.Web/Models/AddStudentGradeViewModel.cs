using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    [PrimaryKey(nameof(SGFSTUDID), nameof(SGFSTUDEDPCODE))]

    public class AddStudentGradeViewModel
    {
        public long SGFSTUDID { get; set; }

        [Required]
        [StringLength(15)]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Subject code must be uppercase alphanumeric characters only.")]
        public string SGFSTUDSUBJCODE { get; set; }

        [Range(0.0, 4.0, ErrorMessage = "Grade must be between 0.0 and 4.0")]
        public double SGFSTUDSUBJGRADE { get; set; }

        [Required]
        [StringLength(8)]
        public string SGFSTUDEDPCODE { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^(Enrollee|Returnee)$", ErrorMessage = "Remarks must be either 'Enrollee' or 'Returnee'")]
        public string SGFSTUDREMARKS { get; set; }
    }
}
