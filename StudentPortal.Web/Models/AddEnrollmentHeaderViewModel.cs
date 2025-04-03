using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    [PrimaryKey(nameof(ENRHFSTUDID))]

    public class AddEnrollmentHeaderViewModel
    {
        public long ENRHFSTUDID { get; set; }
        public DateTime ENRHFSTUDDATEENROLL { get; set; }

        [StringLength(15)]
        public string ENRHFSTUDSCHLYR { get; set; }

        [StringLength(15)]
        public string ENRHFSTUDENCODER { get; set; }

        public double ENRHFSTUDTOTALUNITS { get; set; }

        [StringLength(2)]
        [RegularExpression("EN|UN", ErrorMessage = "choose 2 Letter codes (e.g., EN or UN).")]

        public string ENRHFSTUDSTATUS { get; set; }
    }
}
