namespace StudentPortal.Web.Models
{
    public class AddStudentViewModel
    {
        public string STFSTUDLNAME { get; set; }

        public string STFSTUDFNAME { get; set; }

        public string STFSTUDMNAME { get; set; }

        public string STFSTUDCOURSE { get; set; }

        public int STFSTUDYEAR { get; set; }

        public string STFSTUDREMARKS { get; set; }

        public STFSTUDSTATUSEnum STFSTUDSTATUS { get; set; }
    }

    public enum STFSTUDSTATUSEnum
    {
        A,  // Active
        IN  // Inactive
    }
}
}
