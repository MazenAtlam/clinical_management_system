using Azure;
using System.ComponentModel.DataAnnotations.Schema;
using CCMS.DAL.Enums;

namespace CCMS.DAL.Entities
{
    [Table("Patient", Schema = "ccms")]
    public class Patient : Person
    {
        public int Id { get; private set; }
        public string BloodType { get; private set; }

        // Parameterless constructor for EF
        public Patient() { }

        // Constructor to set all required properties
        public Patient(string fName, string midName, string lName, string ssn, Gender gender, DateTime birthDate, string bloodType, PersonType pType, string createdBy)
        {
            FName = fName;
            MidName = midName;
            LName = lName;
            SSN = ssn;
            Gender = gender;
            BirthDate = birthDate;
            BloodType = bloodType;
            PType = pType;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
        }

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
        }

        //navigation
        public List<PateintFamilyJoin> pateintfFamily { get; set; }
        public List<MedicalHistory> MedicalHistories { get; set; }
        public List<Scan> Scans { get; set; }
        public List<Book> Books { get; set; }
    }
}
