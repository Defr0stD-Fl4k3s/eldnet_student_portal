using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    public class EnrollmentHeaderFile
    {
        [Key]
        public long ENRHFSTUDID { get; set; }
        public DateTime ENRHFSTUDDATEENROLL { get; set; } 

        [StringLength(15)]
        public string ENRHFSTUDSCHLYR { get; set; } 

        [StringLength(15)]
        public string ENRHFSTUDENCODER { get; set; }

        public double ENRHFSTUDTOTALUNITS { get; set; } 

        public EnrollmentStatus ENRHFSTUDSTATUS { get; set; } 
    }

    public enum EnrollmentStatus
    {
        EN, // Enrolled
        UN  // Unenrolled
    }
}
