using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("LabDoctor", Schema = "ccms")]
    public class LabDoctor : Employee
    {
        public List<Scan> Scans { get; private set; } = new List<Scan>();

        public LabDoctor() : base() { }
        public LabDoctor(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate,
            decimal salary, int yearsOfExperience, DateTime hiringDate, int? mgrID, int? deptID, string createdBy)
            : base(fName, midName, lName, ssn, gender, birthDate, salary, yearsOfExperience, hiringDate, mgrID, deptID, createdBy)
        { }
    }
}