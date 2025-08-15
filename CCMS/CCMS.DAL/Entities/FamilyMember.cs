using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("FamilyMember", Schema = "ccms")]
    public class FamilyMember : Base
    {
        public int Id { get; private set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; private set; }
        [Required]
        public Gender Gender { get; private set; }
        [Required]
        [MinLength(14)]
        [MaxLength(14)]
        public string Ssn { get; private set; }
        [Required]
        [MinLength(11)]
        [MaxLength(20)]
        public string PhoneNumber { get; private set; }
        // Navigation
        public List<PatientFamily> PatientFamilyMembers { get; private set; } = new List<PatientFamily>();
        
        //public FamilyMember() : base() { }
        public FamilyMember(string name, Gender gender, string ssn, string phoneNumber, string createdBy)
            : base(createdBy)
            => Set(name, gender, ssn, phoneNumber);

        private void Set(string name, Gender gender, string ssn, string phoneNumber)
        {
            Name = name;
            Gender = gender;
            Ssn = ssn;
            PhoneNumber = phoneNumber;
        }

        public void Edit(string name, Gender gender, string ssn, string phoneNumber, string modifiedBy)
        {
            Set(name, gender, ssn, phoneNumber);
            SaveModification(modifiedBy);
        }
    }
}