using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Models
{
    public class AddSubjectsViewModel
    {
        public string SFSUBJCODE { get; set; }

        public string SFSUBJDESC { get; set; }

        public float SFSUBJUNITS { get; set; }

        public int SFSUBJREGOFRNG { get; set; }

        public string SFSUBJCATEGORY { get; set; }

        public int SFSUBJSTATUS { get; set; }

        public string SFSUBJCOURSECODE { get; set; }

        public SFSUBJSTATUSEnum SFSUBJCURRCODE { get; set; }
    }
    public enum SFSUBJSTATUSEnum
    {
        AC,
        IN
    }
}
