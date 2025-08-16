using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("LabDoctor", Schema = "ccms")]
    public class LabDoctor : Employee
    {
        public virtual List<Scan> Scans { get; private set; } = new List<Scan>();

        //public LabDoctor() : base() { }
        public LabDoctor(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, PersonType pType,
            decimal salary, EmployeeType eType, int yearsOfExperience, DateTime hiringDate, int? mgrId, int? admId, int? deptId, string createdBy)
            : base(fName, midName, lName, ssn, gender, birthDate, pType, salary, eType, yearsOfExperience, hiringDate, mgrId, admId, deptId, createdBy)
        { }
    }
}