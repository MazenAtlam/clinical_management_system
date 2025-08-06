using CCMS.BLL.ModelVM.Person;

namespace CCMS.BLL.ModelVM.Employee
{
    public class EmployeeDTO : PersonDTO
    {
        public decimal Salary { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime HiringDate { get; set; }
        public int? MgrID { get; set; }
        public int? AdmID { get; set; }
        public int? DeptID { get; set; }
    }
}
