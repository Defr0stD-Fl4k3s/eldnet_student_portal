using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    public class SubjectFile
    {
        [Key]
        public string SFSUBJCODE { get; set; } // Primary Key (Part 1)

        [Key]
        public string SFSUBJCOURSECODE { get; set; } // Primary Key (Part 2)

        [StringLength(40)]
        public string SFSUBJDESC { get; set; }

        public float SFSUBJUNITS { get; set; }

        public int SFSUBJREGOFRNG { get; set; }

        [StringLength(3)]
        public string SFSUBJCATEGORY { get; set; } // "lec" or "lab"

        [StringLength(2)]
        public string SFSUBJSTATUS { get; set; } // "AC" or "IN"

        [StringLength(10)]
        public string SFSUBJCURRCODE { get; set; } // Curriculum Code (AY2017)

    }

    public enum SFSUBJSTATUSEnum
    {
        AC,
        IN
    }
}
