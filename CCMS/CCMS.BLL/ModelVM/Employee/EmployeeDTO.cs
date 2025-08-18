using CCMS.BLL.ModelVM.Person;

namespace CCMS.BLL.ModelVM.Employee
{
    public class EmployeeDTO : PersonDTO
    {
        public decimal Salary { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime HiringDate { get; set; }
        public string? MgrId { get; set; }
        public string? AdmId { get; set; }
        public int? DeptId { get; set; }
    }
}
