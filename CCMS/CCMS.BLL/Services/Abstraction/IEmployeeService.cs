using CCMS.BLL.ModelVM.Employee;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDTO>> GetAllEmployees();
        public Task<EmployeeDTO?> GetEmployeeById(int id);
        public Task CreateEmployee(EmployeeDTO dto);
        public Task<bool> UpdateEmployee(int id, EmployeeDTO dto);
        public Task DeleteEmployee(int id);
    }
}