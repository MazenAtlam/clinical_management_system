namespace CCMS.DAL.Entities
{
    public class MedicalHistory : Base
    {
        public int Id { get; private set; }
        public string FamilyHistory { get; private set; }
        public string DiseaseName { get; private set; }

        //navigation
        public Patient Patient { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
    }
}
