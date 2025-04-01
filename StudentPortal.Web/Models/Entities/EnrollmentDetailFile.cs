using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    public class EnrollmentDetailFile
    {
        public long ENRDFSTUDID { get; set; } 

        [StringLength(15)]
        public string ENRDFSTUDSUBJCDE { get; set; } 

        [StringLength(8)]
        public string ENRDFSTUDEDPCODE { get; set; } /

        public EnrollmentDetailStatus ENRDFSTUDSTATUS { get; set; } 
    }
    public enum EnrollmentDetailStatus
    {
        Withdrawn,
        Cancelled
    }
}
