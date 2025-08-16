using CCMS.BLL.ModelVM.Employee;
using CCMS.BLL.ModelVM.WorkingSlot;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDTO>> GetAllEmployees();
        public Task<EmployeeDTO?> GetEmployeeById(int id);
        public Task CreateEmployee(EmployeeDTO dto);
        public Task<bool> UpdateEmployee(int id, EmployeeDTO dto);
        public Task DeleteEmployee(int id);
        public Task<(List<WorkingSlotDTO>?, string?)> GetEmployeeWorkingSlots(int id);
    }
}