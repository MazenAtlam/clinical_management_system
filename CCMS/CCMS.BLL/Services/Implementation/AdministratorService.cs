using CCMS.DAL.Enums;
//using CCMS.BLL.ModelVM.Employee;
using CCMS.BLL.Services.Abstraction;

namespace CCMS.BLL.Services.Implementation
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IAdministratorService adminService = new AdministratorService();

        public string? Create(/*CreateEmployee emp, */string creatingUser)
        {
            throw new NotImplementedException();
        }

        public /*(List<EmployeeDTO>, */string?/*)*/ GetAllEmployeesByRole(/*EmployeeRole role*/)
        {
            throw new NotImplementedException();
        }

        public /*(EmployeeDTO, */string?/*)*/ GetAdminByID(int id)
        {
            throw new NotImplementedException();
        }

        public /*(List<EmployeeDTO>, */string?/*)*/ GetAllEmployeesCrearedBy(int id)
        {
            throw new NotImplementedException();
        }

        public string? Update(/*EmployeeDTO emp, */string modifyingUser)
        {
            throw new NotImplementedException();
        }

        public string? Delete(int id, string modifyingUser)
        {
            throw new NotImplementedException();
        }
    }
}
