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

   
        [ForeignKey("Manager")]
        public int? MgrId { get; private set; }
        public virtual Employee Manager { get; private set; }


        [ForeignKey("Admin")]
        public int? AdmId { get; private set; }
        public virtual Employee Admin { get; private set; }

    
        [ForeignKey("Department")]
        public int? DeptId { get; private set; }
        public virtual Department? Department { get; private set; }
        public virtual List<WorkingSlot> WorkingSlots { get; private set; } = new List<WorkingSlot>();

        //public Employee() : base() { }
        public Employee(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, PersonType pType,
            decimal salary, EmployeeType eType, int yearsOfExperience, DateTime hiringDate, int? mgrId, int? admId, int? deptId, string createdBy)
            : base(fName, midName, lName, ssn, gender, birthDate, pType, createdBy)
        {
            Set(salary, yearsOfExperience, hiringDate, mgrId, deptId);
            EType = eType;
            AdmId = admId;
        }

        private void Set(decimal salary, int yearsOfExperience, DateTime hiringDate, int? mgrId, int? deptId)
        {
            Salary = salary;
            YearsOfExperience = yearsOfExperience;
            MgrId = mgrId;
            DeptId = deptId;
        }

        public void Edit(string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate,
            decimal salary, int yearsOfExperience, DateTime hiringDate, int? mgrId, int? deptId, string modifiedBy)
        {
            base.Edit(fName, midName, lName, ssn, gender, birthDate, modifiedBy);

            Set(salary, yearsOfExperience, hiringDate, mgrId, deptId);
        }
    }
}
