using CCMS.DAL.Entities;


namespace CCMS.DAL.Repository.Abstraction
{
    public interface IEmployeeRepo
    {
        public Task Add(Employee employee);
        public Task<List<Employee>> GetAllEmployees();
        public Task<List<Employee>> GetAllAdmins();
        public Task<List<Employee>> GetAllManagers();
        public Task<Employee> GetEmployeeById(string id);
        public Task<List<Employee>> GetAllEmployeesCrearedByAdmin(string admId);
        public Task Save();
    }
}
