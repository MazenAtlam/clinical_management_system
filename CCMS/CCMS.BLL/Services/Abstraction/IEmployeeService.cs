using CCMS.BLL.ModelVM.Employee;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetAllEmployeesAsync();
        Task<EmployeeDTO?> GetEmployeeByIdAsync(int id);
        Task<EmployeeDTO> CreateEmployeeAsync(EmployeeDTO dto);
        Task<bool> UpdateEmployeeAsync(int id, EmployeeDTO dto);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}