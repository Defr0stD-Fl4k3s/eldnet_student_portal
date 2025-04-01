using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    public class SubjectSchedFile
    {
        [StringLength(8)]
        public string SSFEDPCODE { get; set; }
        [StringLength(15)]
        public string SSFSUBJCODE { get; set; }
        public DateTime SSFSTARTTIME   { get; set; }
        public DateTime SSFENDTIME { get; private set; }
        [StringLength(3)]
        public string SSFDAYS { get; set; } 
        public string SSFROOM {  get; set; } 

        public int SSFMAXSIZE { get; set; }

        public int SSFCLASSSIZE {  get; set; }

        public SSFStatus SSFSTATUS { get; set; }
        
        public SSFxm SSFXM { get; set; }

        [StringLength(3)]
        public string SSFSECTION { get; set; }

        public int SSFSCHOOLYEAR { get; set; }
            

    }

    public enum SSFStatus
    {
        Active,
        Inactive,
        Dissolved,
        Restricted,
        Closed
    }

    public enum SSFxm
    {
        AM,
        PM
    }
}
