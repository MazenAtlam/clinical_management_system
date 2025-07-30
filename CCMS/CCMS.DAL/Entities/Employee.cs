using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CCMS.DAL.Entities
{
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
        public Department Department { get; private set; }

    }
}
