using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    [PrimaryKey(nameof(SSFEDPCODE))]

    public class AddSubjectSchedViewModel
    {
        [StringLength(8)]
        public string SSFEDPCODE { get; set; }

        [StringLength(15)]
        public string SSFSUBJCODE { get; set; }

        public DateTime SSFSTARTTIME { get; set; }
        public DateTime SSFENDTIME { get; set; }

        [StringLength(3)]
        [RegularExpression("MON|TUE|WED|THU|FRI|SAT|SUN", ErrorMessage = "Invalid day code")]
        public string SSFDAYS { get; set; }

        [StringLength(3)]
        public string SSFROOM { get; set; }

        public int SSFMAXSIZE { get; set; }
        public int SSFCLASSSIZE { get; set; }

        [StringLength(3)]
        [RegularExpression("ACT|INA|DIS|RES|CLO", ErrorMessage = "Invalid status code")]
        public string SSFSTATUS { get; set; }

        [StringLength(3)]
        [RegularExpression("AM|PM", ErrorMessage = "Invalid time period")]
        public string SSFXM { get; set; }

        [StringLength(3)]
        public string SSFSECTION { get; set; }

        public int SSFSCHOOLYEAR { get; set; }
    }
}
