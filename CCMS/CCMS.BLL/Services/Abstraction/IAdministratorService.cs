using CCMS.BLL.ModelVM.Employee;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IAdministratorService
    {
        public Task<string?> Create(EmployeeDTO emp, string creatingUser);

        public Task<(List<EmployeeDTO>?, string?)> GetAllAdmins();

        public Task<(EmployeeDTO?, string?)> GetAdminByID(int id);

        public Task<(List<EmployeeDTO>?, string?)> GetAllEmployeesCrearedBy(int id);

        public Task<string?> Update(EmployeeDTO emp, string modifyingUser);

        public Task<string?> Delete(int id, string modifyingUser);
    }
}
