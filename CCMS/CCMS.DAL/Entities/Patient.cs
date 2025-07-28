namespace CCMS.DAL.Entities
{
    [Table("Patient", Schema = "ccms")]
    public class Patient : Person
    {
        
        public int Id { get;private set; }

        //navigation
        public List<PateintfFamilyJoin> pateintfFamily { get; set; }
        public List<MedicalHistory> MedicalHistories { get; set; }
        public List<Scan> Scans { get; set; }

        public List<Book> Books { get; set; }
    }
}
