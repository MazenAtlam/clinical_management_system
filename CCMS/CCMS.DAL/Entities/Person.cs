using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Person", Schema="ccms")]
    public abstract class Person : Base
    {
        [Key]
        public int UID { get; private set; }

        [Required]
        [MaxLength(50)]
        public string FName { get; private set; }

        [MaxLength(50)]
        public string? MidName { get; private set; }

        [Required]
        [MaxLength(50)]
        public string LName { get; private set; }

        [Required]
        [MinLength(14)]
        [MaxLength(14)]
        public string SSN { get; private set; }

        [Required]
        public Gender Gender { get; private set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; private set; }

        [Required]
        public PersonType PType { get; private set; }
        public List<PhoneNumber> PhoneNumbers { get; private set; } = new List<PhoneNumber>();
        public List<Address> Addresses { get; private set; } = new List<Address>();

        protected Person() : base() { }
        protected Person(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, string createdBy)
            : base(createdBy)
            => Set(fName, midName, lName, ssn, gender, birthDate);

        public string GetFullName() => $"{FName} {MidName} {LName}";

        private void Set(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate)
        {
            FName = fName;
            MidName = midName;
            LName = lName;
            SSN = SSN;
            Gender = gender;
            BirthDate = birthDate;
        }

        public void Edit(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, string modifiedBy)
        {
            Set(fName, midName, lName, ssn, gender, birthDate);

            base.SaveModification(modifiedBy);
        }
    }
}
