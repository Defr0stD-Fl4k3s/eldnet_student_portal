using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    public class AddSubjectsViewModel
    {
        [StringLength(15)]
        public string SFSUBJCODE { get; set; }

        [StringLength(40)]
        public string SFSUBJDESC { get; set; }

        public float SFSUBJUNITS { get; set; }

        public int SFSUBJREGOFRNG { get; set; }

        [StringLength(3)]
        [RegularExpression("lec|lab", ErrorMessage = "SFSUBJCATEGORY must be 'lec' or 'lab'.")]
        public string SFSUBJCATEGORY { get; set; }

        [StringLength(2)]
        [RegularExpression("AC|IN", ErrorMessage = "SFSUBJSTATUS must be 'AC' or 'IN'.")]
        public string SFSUBJSTATUS { get; set; }

        [StringLength(5)]
        public string SFSUBJCOURSECODE { get; set; }

        [StringLength(10)]
        [RegularExpression(@"AY\d{4}", ErrorMessage = "SFSUBJCURRCODE must follow the format 'AYYYYYY', e.g., AY2017")]
        public string SFSUBJCURRCODE { get; set; }
    }
}
