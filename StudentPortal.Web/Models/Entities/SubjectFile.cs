namespace StudentPortal.Web.Models.Entities
{
    public class SubjectFile
    {
        public string SFSUBJCODE { get; set; }

        public string SFSUBJDESC { get; set; }

        public float SFSUBJUNITS { get; set; }

        public int SFSUBJREGOFRNG { get; set; }

        public string SFSUBJCATEGORY { get; set; }

        public SFSUBJSTATUSEnum SFSUBJSTATUS { get; set; }

        public string SFSUBJCOURSECODE { get; set; }

        public string  SFSUBJCURRCODE { get; set; }

    }

    public enum SFSUBJSTATUSEnum
    {
        AC,
        IN
    }
}
