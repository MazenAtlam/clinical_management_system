using CCMS.BLL.ModelVM.Employee;
using CCMS.BLL.ModelVM.WorkingSlot;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDTO>> GetAllEmployees();
        public Task<EmployeeDTO?> GetEmployeeById(string id);
        public Task CreateEmployee(EmployeeDTO dto);
        public Task<bool> UpdateEmployee(EmployeeDTO dto);
        public Task DeleteEmployee(string id);
        public Task<(List<WorkingSlotDTO>?, string?)> GetEmployeeWorkingSlots(string id);
    }
}