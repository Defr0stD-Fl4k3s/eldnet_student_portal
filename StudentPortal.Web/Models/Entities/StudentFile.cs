using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    [PrimaryKey(nameof(STFSTUDID))]
    public class StudentFile
    {
        [Key]
        public long STFSTUDID { get; set; }

        [Required]
        [StringLength(15)]
        public string STFSTUDLNAME { get; set; }

        [Required]
        [StringLength(15)]
        public string STFSTUDFNAME { get; set; }

        [StringLength(15)]
        public string STFSTUDMNAME { get; set; }

        [Required(ErrorMessage = "Course is required.")]
        [StringLength(10)]
        public string STFSTUDCOURSE { get; set; }

        [Required]
        public int STFSTUDYEAR { get; set; }

        [Required]
        [StringLength(2)]
        [RegularExpression("^(A|IN)$", ErrorMessage = "Status must be 'A' or 'IN'.")]
        public string STFSTUDSTATUS { get; set; }

        [Required]
        [StringLength(15)]
        [RegularExpression("^(Shiftee|Transferee|New|Old|Cross-Enrollee|Returnee)$",ErrorMessage = "Remarks must be one of the predefined values.")]
        public string STFSTUDREMARKS { get; set; }
    }
}