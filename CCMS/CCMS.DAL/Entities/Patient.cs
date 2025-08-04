using Azure;
using System.ComponentModel.DataAnnotations.Schema;
using CCMS.DAL.Enums;

namespace CCMS.DAL.Entities
{
    [Table("Patient", Schema = "ccms")]
    public class Patient : Person
    {
        public int Id { get; private set; }
        public string BloodType { get; set; }

        // Edit method to update patient info (name, ssn, gender, birthdate, bloodtype)
        public void Edit(string fName, string midName, string lName, string ssn, Gender gender, DateTime birthDate, string bloodType)
        {
            this.FName = fName;
            this.MidName = midName;
            this.LName = lName;
            this.SSN = ssn;
            this.Gender = gender;
            this.BirthDate = birthDate;
            this.BloodType = bloodType;
            this.ModifiedOn = DateTime.Now;
        }

        //navigation
        public List<PateintFamilyJoin> pateintfFamily { get; set; }
        public List<MedicalHistory> MedicalHistories { get; set; }
        public List<Scan> Scans { get; set; }
        public List<Book> Books { get; set; }
    }
}