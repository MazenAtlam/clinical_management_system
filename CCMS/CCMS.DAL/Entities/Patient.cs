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
        // Navigation
        public virtual List<PatientFamily> PatientFamilyMembers { get; private set; } = new List<PatientFamily>();
        public virtual List<MedicalHistory> MedicalHistories { get; private set; } = new List<MedicalHistory>();
        public virtual List<Scan> Scans { get; private set; } = new List<Scan>();
        public virtual List<Book> Books { get; private set; } = new List<Book>();

        //public Patient() : base() { }
        public Patient(UserType uType, string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, BloodType bloodType, string? path, string createdBy)
            : base(uType, fName, midName, lName, ssn, gender, birthDate, createdBy)
            => BloodType = bloodType;

        public void Edit(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, BloodType bloodType, string? path,string modifiedBy)
        {
            base.Edit(fName, midName, lName, ssn, gender, birthDate, path,modifiedBy);
            BloodType = bloodType;
        }
    }
}
