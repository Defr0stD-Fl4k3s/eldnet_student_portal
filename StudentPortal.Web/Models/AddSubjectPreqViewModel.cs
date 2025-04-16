using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    [PrimaryKey(nameof(SUBJCODE), nameof(SUBJPRECODE))]
    public class AddSubjectPreqViewModel
    {
        [Required(ErrorMessage = "Subject code is required.")]
        [StringLength(15)]
        public string SUBJCODE { get; set; }

        [Required(ErrorMessage = "Prerequisite subject code is required.")]
        [StringLength(15)]
        public string SUBJPRECODE { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [StringLength(2)]
        [RegularExpression("CR|PR", ErrorMessage = "Must be 'CR' or 'PR'.")]
        public string SUBJCATEGORY { get; set; } // "CR" or "PR"
    }
}
