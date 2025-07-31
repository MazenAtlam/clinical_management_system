using System.ComponentModel.DataAnnotations.Schema;
namespace CCMS.DAL.Entities
{
    [Table("MedicalHistory", Schema = "ccms")]
    public class MedicalHistory : Base
    {

        public int Id { get; private set; }
        public string FamilyHistory { get; private set; }
        public string DiseaseName { get; private set; }

        //navigation
        public Patient Patient { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public void Edit(string familyHistory, string diseaseName, int patientId)
        {
            this.FamilyHistory = familyHistory;
            this.DiseaseName = diseaseName;
            this.PatientId = patientId;
            this.ModifiedOn = DateTime.Now;
        }
    }
}