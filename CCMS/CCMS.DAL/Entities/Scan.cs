using System.ComponentModel.DataAnnotations.Schema;
namespace CCMS.DAL.Entities
{
    [Table("Scan", Schema = "ccms")]
    public class Scan : Base
    {

        public int Id { get; private set; }
        public string ScanType { get; private set; }
        public string ScanTech { get; private set; }
        public string? Results { get; private set; } //file location
        public DateTime SDate { get; private set; }

        //constructor
        //public Scan(string scanType, string scanTech, string? results, DateTime sDate, string creatingUser)
        //    : base(creatingUser)
        //{
        //    ScanType = scanType;
        //    ScanTech = scanTech;
        //    Results = results;
        //    SDate = sDate;
        //}
        ////default constructor
        //public Scan(){ }
        public void Edit(string scanType,string scanTech,DateTime SDate,int PatientId,string? Results)
        {
            //this.ModifiedOn = DateTime.Now;
            // Take the modifyingUser as parameter for the attribute "ModifiedBy", then Use the following line
            // SaveModification(modifyingUser);
            ScanType = scanType;
            ScanTech = scanTech;
            this.SDate = SDate;
            this.PatientId = PatientId;
            this.Results = Results;
        }
        //navigation
        public Patient Patient { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

    }
}