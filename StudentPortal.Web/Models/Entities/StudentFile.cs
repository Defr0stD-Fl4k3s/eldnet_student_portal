using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    public class StudentFile
    {
        [Key]
        public long STFSTUDID { get; set; }
        
        public string STFSTUDLNAME { get; set; }

        public string STFSTUDFNAME { get; set; }

        public string STFSTUDMNAME { get; set; }
        
        public string STFSTUDCOURSE { get;set; }

        public int STFSTUDYEAR { get;set; }

        public string STFSTUDREMARKS{ get; set; }

        public STFSTUDSTATUSEnum STFSTUDSTATUS { get; set; }
    }

    public enum STFSTUDSTATUSEnum
    {
        A,  // Active
        IN  // Inactive
    }


}
