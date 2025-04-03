using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StudentPortal.Web.Models.Entities
{
    [PrimaryKey(nameof(SFSUBJCODE), nameof(SFSUBJCOURSECODE))]
    public class SubjectFile
    {
        public string SFSUBJCODE { get; set; } // Primary Key (Part 1)

        public string SFSUBJCOURSECODE { get; set; } // Primary Key (Part 2)

        [StringLength(40)]
        public string SFSUBJDESC { get; set; }

        public float SFSUBJUNITS { get; set; }

        public int SFSUBJREGOFRNG { get; set; }

        [StringLength(3)]
        [RegularExpression("lec|lab", ErrorMessage = "SFSUBJCATEGORY must be 'lec' or 'lab'.")]
        public string SFSUBJCATEGORY { get; set; } // "lec" or "lab"

        [StringLength(2)]
        [RegularExpression("AC|IN", ErrorMessage = "SFSUBJSTATUS must be 'AC' or 'IN'.")]
        public string SFSUBJSTATUS { get; set; } // "AC" or "IN"

        [StringLength(10)]
        public string SFSUBJCURRCODE { get; set; } // Curriculum Code (AY2017)

    }


}
