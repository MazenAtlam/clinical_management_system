using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CCMS.DAL.Entities
{
    [Table("Employee", Schema="ccms")]
    public class Employee : Person
    {
        [Required]
       
        public decimal Salary { get; private set; }

        [Required]
        public EmployeeType EType { get; private set; }

        [Required]
        [Range(0, 50)] 
        public int YearsOfExperience { get; private set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; private set; }

   
        public int? MgrId { get; private set; }
        [ForeignKey("MgrId")]
        public Employee Manager { get; private set; }


        public int? AdmId { get; private set; }
        [ForeignKey("AdmId")]
        public Employee Admin { get; private set; }

    
        public int? DeptId { get; private set; }
        [ForeignKey("DeptId")]
        public Department? Department { get; private set; }
        public List<WorkingSlot> WorkingSlots { get; private set; } = new List<WorkingSlot>();

        public Employee() : base() { }
        public Employee(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate,
            decimal salary, int yearsOfExperience, DateTime hiringDate, int? mgrID, int? deptID, string createdBy)
            : base(fName, midName, lName, ssn, gender, birthDate, createdBy)
            => Set(salary, yearsOfExperience, hiringDate, mgrID, deptID);

        private void Set(decimal salary, int yearsOfExperience, DateTime hiringDate, int? mgrID, int? deptID)
        {
            Salary = salary;
            YearsOfExperience = yearsOfExperience;
            MgrId = mgrID;
            DeptId = deptID;
        }

        public void Edit(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate,
            decimal salary, int yearsOfExperience, DateTime hiringDate, int? mgrID, int? deptID, string modifiedBy)
        {
            base.Edit(fName, midName, lName, ssn, gender, birthDate, modifiedBy);

            Set(salary, yearsOfExperience, hiringDate, mgrID, deptID);
        }
    }
}
