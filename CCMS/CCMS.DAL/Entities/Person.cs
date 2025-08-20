using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Person", Schema="ccms")]
    public abstract class Person : ApplicationUser
    {
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
        public string Ssn { get; private set; }

        [Required]
        public Gender Gender { get; private set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; private set; }
        public string? Path { get; private set; }
        public virtual List<PhoneNumber> PhoneNumbers { get; private set; } = new List<PhoneNumber>();
        public virtual List<Address> Addresses { get; private set; } = new List<Address>();

        //protected Person() : base() { }
        protected Person(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, string createdBy, string? path)
            : base(createdBy)
        {
            Set(fName, midName, lName, ssn, gender, birthDate, path);
        }

        public string GetFullName() => FName + (MidName == null ? " " : $" {MidName} ") + LName;

        private void Set(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, string path)
        {
            FName = fName;
            MidName = midName;
            LName = lName;
            Ssn = ssn;
            Gender = gender;
            BirthDate = birthDate;
            Path = path;
        }

        public void Edit(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, string? path,string modifiedBy)
        {
            Set(fName, midName, lName, ssn, gender, birthDate, path);

            base.SaveModification(modifiedBy);
        }
    }
}
