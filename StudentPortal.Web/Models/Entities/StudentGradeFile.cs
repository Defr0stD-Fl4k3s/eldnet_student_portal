using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    public class StudentGradeFile
    {
        [Key]
        public long SGFSTUDID {  get; set; }

        public string SGFSTUDSUBJCODE { get; set; }

        public double SGFSTUDSUBJGRADE { get; set; }

        public string SGFSTUDEDPCODE { get; set; }

        public STUDremarks SGFSTUDREMARKS {  get; set; }

    }

    public enum STUDremarks
    {
        Enrollee,
        Returnee
    }


}
