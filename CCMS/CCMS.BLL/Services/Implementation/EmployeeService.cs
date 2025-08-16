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
        private readonly EmployeeMapper mapper = new EmployeeMapper();

        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            var employees = await _employeeRepo.GetAllEmployees();
            return mapper.ToListResponseDto(employees);
        }

        public async Task<EmployeeDTO?> GetEmployeeById(int id)
        {
            var employee = await _employeeRepo.GetEmployeeById(id);
            return employee == null ? null : mapper.ToResponseDto(employee);
        }

        public async Task CreateEmployee(EmployeeDTO dto)
        {
            var employee = mapper.ToEntity(dto);
            await _employeeRepo.Add(employee);
            await _employeeRepo.Save();
        }

        public async Task<bool> UpdateEmployee(EmployeeDTO dto)
        {
            var existingEmployee = await _employeeRepo.GetEmployeeById(dto.UID);
            //if (existingEmployee == null) return false;


            existingEmployee.Edit(
       dto.FName,
       dto.MidName,
       dto.LName,
       dto.Ssn,
       dto.Gender, 
       dto.BirthDate,
       dto.Salary,
       dto.YearsOfExperience,
       dto.HiringDate,
       dto.MgrId,
       dto.DeptId,
       "System"
   );



            await _employeeRepo.Save();
            return true;
        }

        public async Task DeleteEmployee(int id)
        {
            var existingEmployee = await _employeeRepo.GetEmployeeById(id);
            existingEmployee.Delete("Admin");
            await _employeeRepo.Save();
        }

        public Task<bool> UpdateEmployee(int id, EmployeeDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
