using Azure;
using System.ComponentModel.DataAnnotations.Schema;
namespace CCMS.DAL.Entities
{
    [Table("Patient", Schema = "ccms")]
    public class Patient : Person
    {

        public int Id { get; private set; }
        public string BloodType { get; set; }
        public string? Allergies { get; set; }

        //fix when person class is done
        public void Edit(/* params*/)
        {
            this.ModifiedOn = DateTime.Now;
        }

        //navigation
        public List<PateintFamilyJoin> pateintfFamily { get; set; }
        public List<MedicalHistory> MedicalHistories { get; set; }
        public List<Scan> Scans { get; set; }

        public List<Book> Books { get; set; }
    }
}