namespace StudentPortal.Web.Models.Entities
{
    public class SubjectPreqFile
    {
        public string SUBJCODE { get; set; }
        public string SUBJPRECODE {  get; set; }

        public SubjectCategory SUBJCATEGORY { get; set; }

    }

    public enum SubjectCategory
    {
        CR,
        PR
    }
}
