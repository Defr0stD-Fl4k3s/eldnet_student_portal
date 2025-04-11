using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{

    public class AddStudentViewModel
    {
        [Key]
        public long STFSTUDID { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(15)]
        public string STFSTUDLNAME { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(15)]
        public string STFSTUDFNAME { get; set; }

        [StringLength(15)]
        public string STFSTUDMNAME { get; set; }

        [Required(ErrorMessage = "Course is required.")]
        [StringLength(10)]
        public string STFSTUDCOURSE { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1, 10, ErrorMessage = "Year must be between 1 and 10.")]
        public int STFSTUDYEAR { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression("^(A|IN)$", ErrorMessage = "Status must be 'A' or 'IN'.")]
        public string STFSTUDSTATUS { get; set; }

        [Required(ErrorMessage = "Remarks are required.")]
        [RegularExpression("^(Shiftee|Transferee|New|Old|Cross-Enrollee|Returnee)$",ErrorMessage = "Remarks must be one of the predefined values.")]
        public string STFSTUDREMARKS { get; set; }
    }
}