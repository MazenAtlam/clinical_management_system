using CCMS.BLL.ModelVM.Employee;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Repository.Abstraction;
using CCMS.BLL.Mapping;
using CCMS.DAL.Entities;

namespace CCMS.BLL.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepo.GetAllEmployees();
            return EmployeeMapper.ToListResponseDto(employees.ToList());
        }

        public async Task<EmployeeDTO?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepo.GetEmployeeById(id);
            return employee == null ? null : EmployeeMapper.ToResponseDto(employee);
        }

        public async Task<EmployeeDTO> CreateEmployeeAsync(EmployeeDTO dto)
        {
            var employee = EmployeeMapper.ToEntity(dto);
            var createdEmployee = await _employeeRepo.CreateEmployee(employee);
            return EmployeeMapper.ToResponseDto(createdEmployee);
        }

        public async Task<bool> UpdateEmployeeAsync(int id, EmployeeDTO dto)
        {
            var existingEmployee = await _employeeRepo.GetEmployeeById(id);
            if (existingEmployee == null) return false;


            existingEmployee.Edit(
       dto.FName,
       dto.MidName,
       dto.LName,
       dto.SSN,
       dto.Gender, 
       dto.BirthDate,
       dto.Salary,
       dto.YearsOfExperience,
       dto.HiringDate,
       dto.MgrID,
       dto.DeptID,
       "System"
   );



            await _employeeRepo.UpdateEmployee(existingEmployee);
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await _employeeRepo.DeleteEmployee(id);
        }
    }
}
