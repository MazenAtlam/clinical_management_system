using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Repository.Abstraction;
using CCMS.BLL.ModelVM.Employee;
using CCMS.BLL.Mapping;
using CCMS.DAL.Entities;

namespace CCMS.BLL.Services.Implementation
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IEmployeeRepo administratorRepo;

        public AdministratorService(IEmployeeRepo repo) => administratorRepo = repo;

        public async Task<string?> Create(EmployeeDTO emp, string creatingUser)
        {
            //try
            //{
            //    Employee employee = EmployeeMapper.ToEntity(emp);
            //    await administratorRepo.CreateEmployee(employee);
            //}
            throw new NotImplementedException();
        }

        public async Task<(List<EmployeeDTO>?, string?)> GetAllAdmins()
        {
            throw new NotImplementedException();
        }

        public async Task<(EmployeeDTO?, string?)> GetAdminByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<(List<EmployeeDTO>?, string?)> GetAllEmployeesCrearedBy(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> Update(EmployeeDTO emp, string modifyingUser)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> Delete(int id, string modifyingUser)
        {
            throw new NotImplementedException();
        }
    }
}
