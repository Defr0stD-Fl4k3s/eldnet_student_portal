using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    public class SubjectPreqFile
    {
        public string SUBJCODE { get; set; }
        
        public string SUBJPRECODE {  get; set; }
        [StringLength(2)]
        public SubjectCategory SUBJCATEGORY { get; set; }

    }

    public enum SubjectCategory
    {
        CR,
        PR
    }
}
