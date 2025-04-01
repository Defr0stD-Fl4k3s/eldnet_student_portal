namespace StudentPortal.Web.Models.Entities
{
    public class SubjectSchedFile
    {
        public string SSFEDPCODE { get; set; }
        public string SSFSUBJCODE { get; set; }
        public DateTime SSFSTARTTIME   { get; set; }
        public DateTime SSFENDTIME { get; private set; }
        public string SSFDAYS { get; set; } 
        public string SSFROOM {  get; set; } 

        public int SSFMAXSIZE { get; set; }

        public int SSFCLASSSIZE {  get; set; }

        public string SSFSTATUS { get; set; }
        
        public string SSFXM { get; set; }

        public string SSFSECTION { get; set; }

        public int SSFSCHOOLYEAR { get; set; }


    }
}
