using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Doctor", Schema = "ccms")]
    public class Doctor : Employee
    {
        public Specialization major { get; private set; }
        public Rating? rating { get; private set; }
        // Navigation
        public virtual List<Book> Books { get; private set; }

        //public Doctor() : base() { }
        public Doctor(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, string? path,
            decimal salary, int? yearsOfExperience, DateTime hiringDate, string? mgrId, string? admId, int? deptId,
            Specialization major, string createdBy)
            : base(fName, midName, lName, ssn, gender, birthDate, path, salary, yearsOfExperience, hiringDate, mgrId, admId, deptId, createdBy)
            => this.major = major;

        public void EditRating(Rating? rating, string modifiedBy)
        {
            this.rating = rating;
            SaveModification(modifiedBy);
        }

        public void Edit(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, string? path,
            decimal salary, int? yearsOfExperience, DateTime hiringDate, string? mgrId, int? deptId,
            Specialization major, Rating? rating, string modifiedBy)
        {
            base.Edit(fName, midName, lName, ssn, gender, birthDate, path, salary, yearsOfExperience, hiringDate, mgrId, deptId, modifiedBy);
            this.major = major;
            this.rating = rating;
        }
    }
}