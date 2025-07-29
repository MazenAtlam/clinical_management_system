using CCMS.DAL.Entities;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IAdministratorService
    {
        public string? Create(/*CreateEmployee emp, */string creatingUser);

        public /*(List<EmployeeDTO>, */string?/*)*/ GetAllEmployeesByRole(/*EmployeeRole role*/);

        public /*(EmployeeDTO, */string?/*)*/ GetAdminByID(int id);

        public /*(List<EmployeeDTO>, */string?/*)*/ GetAllEmployeesCrearedBy(int id);

        public string? Update(/*EmployeeDTO emp, */string modifyingUser);

        public string? Delete(int id, string modifyingUser);
    }
}
