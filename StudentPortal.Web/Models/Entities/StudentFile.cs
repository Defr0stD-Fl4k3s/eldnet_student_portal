using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    public class StudentFile
    {
        [Key]
        public long STFSTUDID { get; set; }
        [StringLength(15)]
        public string STFSTUDLNAME { get; set; }

        [StringLength(15)]
        public string STFSTUDFNAME { get; set; }

        [StringLength(15)]
        public string STFSTUDMNAME { get; set; }

        [StringLength(10)]
        public string STFSTUDCOURSE { get; set; }

        public int STFSTUDYEAR { get; set; }

        [StringLength(15)]
        public STFSTUDREMARKSEnum STFSTUDREMARKS { get; set; } // (Shiftee, Transferee, etc.)

        public STFSTUDSTATUSEnum STFSTUDSTATUS { get; set; }
    }

    public enum STFSTUDSTATUSEnum
    {
        A,  // Active
        IN  // Inactive
    }

    public enum STFSTUDREMARKSEnum
    {
        Shiftee,
        Transferee,
        New,
        Old,
        CrossEnrollee,
        Returnee

    }


}
