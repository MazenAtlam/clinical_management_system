using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("LabDoctor", Schema = "ccms")]
    public class LabDoctor : Employee
    {
        public virtual List<Scan> Scans { get; private set; } = new List<Scan>();

        //public LabDoctor() : base() { }
        public LabDoctor(UserType uType, string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, string? path,
            decimal salary, int? yearsOfExperience, DateTime hiringDate, string? mgrId, string? admId, int? deptId, string createdBy)
            : base(uType, fName, midName, lName, ssn, gender, birthDate, path, salary, yearsOfExperience, hiringDate, mgrId, admId, deptId, createdBy)
        { }
    }
}