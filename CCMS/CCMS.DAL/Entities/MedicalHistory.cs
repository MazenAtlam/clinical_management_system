namespace CCMS.DAL.Entities
{
    public class MedicalHistory : Base
    {
        public int Id { get; set; }
        public string FamilyHistory { get; set; }
        public string DiseaseName { get; set; }

        //navigation
        public Patient Patient { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
    }
}
