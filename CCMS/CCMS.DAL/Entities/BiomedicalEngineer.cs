using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("BiomedicalEngineer", Schema = "ccms")]
    public class BiomedicalEngineer : Employee
    {
        public virtual List<MedicalDevice> MedicalDevices { get; private set; } = new List<MedicalDevice>();

        //public BiomedicalEngineer() : base() { }
        public BiomedicalEngineer(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, string? path,
            decimal salary, int? yearsOfExperience, DateTime hiringDate, string? mgrId, string? admId, int? deptId, string createdBy)
            : base(fName, midName, lName, ssn, gender, birthDate, path, salary, yearsOfExperience, hiringDate, mgrId, admId, deptId, createdBy)
        { }
    }
}
