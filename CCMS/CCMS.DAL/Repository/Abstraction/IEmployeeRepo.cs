using CCMS.DAL.Entities;


namespace CCMS.DAL.Repository.Abstraction
{
    public interface IEmployeeRepo
    {
        public Task Add(Employee employee);
        public Task<List<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployeeById(int id);
        public Task Save();
    }
}
