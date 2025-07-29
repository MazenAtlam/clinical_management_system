using System.ComponentModel.DataAnnotations.Schema;
namespace CCMS.DAL.Entities
{
    [Table("Scan", Schema = "ccms")]
    public class Scan : Base
    {

        public int Id { get; private set; }
        public string ScanType { get; private set; }
        public string ScanTech { get; private set; }
        public string Results { get; private set; } //file location
        public DateTime SDate { get; private set; }

        //navigation
        public Patient Patient { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

    }
}