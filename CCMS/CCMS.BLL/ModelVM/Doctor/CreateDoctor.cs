using CCMS.BLL.ModelVM.Employee;
using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.Doctor
{
    public class CreateDoctor : CreateEmployee
    {
        public Specialization major { get; set; }
    }
}
