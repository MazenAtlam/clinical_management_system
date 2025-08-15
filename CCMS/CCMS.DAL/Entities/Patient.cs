using System.ComponentModel.DataAnnotations.Schema;
using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace CCMS.DAL.Entities
{
    [Table("Patient", Schema = "ccms")]
    public class Patient : Person
    {
        [Required]
        public BloodType BloodType { get; private set; }

        //public Patient() : base() { }
        public Patient(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, BloodType bloodType, string createdBy)
            : base(fName, midName, lName, ssn, gender, birthDate, createdBy)
            => BloodType = bloodType;

        public void Edit(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, BloodType bloodType, string modifiedBy)
        {
            base.Edit(fName, midName, lName, ssn, gender, birthDate, modifiedBy);
            BloodType = bloodType;
        }

        // Navigation
        public List<PatientFamily> PatientFamilyMembers { get; private set; } = new List<PatientFamily>();
        public List<MedicalHistory> MedicalHistories { get; private set; }= new List<MedicalHistory>();
        public List<Scan> Scans { get; private set; } = new List<Scan>();
        public List<Book> Books { get; private set; } = new List<Book>();
    }
}
