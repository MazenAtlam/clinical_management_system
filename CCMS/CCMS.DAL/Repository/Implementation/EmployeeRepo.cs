using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly CcmsDbContext _context;

        public EmployeeRepo(CcmsDbContext context) => _context = context;

        public async Task Add(Employee employee) => _context.Employees.Add(employee);

        public async Task<List<Employee>> GetAllEmployees()
            => _context.Employees.Where(a => !a.IsDeleted).ToList();
        public async Task<List<Employee>> GetAllAdmins()
            => _context.Employees.Where(a => !a.IsDeleted && a.UType == UserType.Admin).ToList();
        public async Task<List<Employee>> GetAllManagers()
            => _context.Employees.Where(a => !a.IsDeleted && a.UType == UserType.Manager).ToList();

        public async Task<Employee> GetEmployeeById(string id)
        {
            Employee? employee = _context.Employees.Where(a => a.Id == id && !a.IsDeleted).FirstOrDefault();

            return employee == null
                ? throw new ArgumentException($"There is no Employee with this ID", "id")
                : employee;
        }

        public async Task<List<Employee>> GetAllEmployeesCrearedByAdmin(string admId)
            =>_context.Employees.Where(a => !a.IsDeleted && a.AdmId == admId).ToList();

        public async Task Save() => _context.SaveChanges();
    }
}
