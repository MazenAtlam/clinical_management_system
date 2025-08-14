using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly CcmsDbContext _context;

        public EmployeeRepo(CcmsDbContext context) => _context = context;

        public async Task Add(Employee employee) => _context.Employees.Add(employee);

        public async Task<List<Employee>> GetAllEmployees() => _context.Employees.Where(a => !a.IsDeleted).ToList();

        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee? employee = _context.Employees.Where(a => a.UID == id && !a.IsDeleted).FirstOrDefault();

            return employee == null
                ? throw new ArgumentException($"There is no Employee with the ID = {id}", "id")
                : employee;
        }

        public async Task Save() => _context.SaveChanges();
    }
}
