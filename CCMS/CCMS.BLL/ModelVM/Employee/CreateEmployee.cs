using CCMS.BLL.ModelVM.Person;
using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.Employee
{
    public class CreateEmployee : CreatePerson
    {
        public decimal Salary { get; set; }
        public EmployeeType EType { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime HiringDate { get; set; }
        public int? MgrId { get; set; }
        public int? AdmId { get; set; }
        public int? DeptId { get; set; }
    }
}
