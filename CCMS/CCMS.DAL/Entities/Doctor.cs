using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Doctor", Schema = "ccms")]
    public class Doctor : Employee
    {
        public Specialization major { get; private set; }
        public Rating rating { get; private set; }
        // Navigation
        public List<Book> Books { get; private set; }

        //public Doctor() : base() { }
        public Doctor(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate,
            decimal salary, int yearsOfExperience, DateTime hiringDate, int? mgrId, int? admId, int? deptId,
            Specialization major, Rating rating, string createdBy)
            : base(fName, midName, lName, ssn, gender, birthDate, salary, yearsOfExperience, hiringDate, mgrId, admId, deptId, createdBy)
            => Set(major, rating);

        private void Set(Specialization major, Rating rating)
        {
            this.major = major;
            this.rating = rating;
        }

        public void EditRating(Rating rating, string modifiedBy)
        {
            this.rating = rating;
            SaveModification(modifiedBy);
        }

        public void Edit(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate,
            decimal salary, int yearsOfExperience, DateTime hiringDate, int? mgrId, int? deptId,
            Specialization major, Rating rating, string modifiedBy)
        {
            base.Edit(fName, midName, lName, ssn, gender, birthDate, salary, yearsOfExperience, hiringDate, mgrId, deptId, modifiedBy);
            Set(major, rating);
        }
    }
}