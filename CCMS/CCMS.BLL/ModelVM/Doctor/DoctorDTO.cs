using CCMS.BLL.ModelVM.Employee;
using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.Doctor
{
    public class DoctorDTO : EmployeeDTO
    {
        public Specialization major { get; set; }
        public Rating rating { get; set; }
    }
}
