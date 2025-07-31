using CCMS.BLL.Services.Abstraction;

namespace CCMS.BLL.Services.Implementation
{
    public class ManagerService : IManagerService
    {
        public string? Create(/*CreateEmployee emp, */string creatingUser)
        {
            throw new NotImplementedException();
        }

        public /*(List<EmployeeDTO>?, */string?/*)*/ GetAllManagers()
        {
            throw new NotImplementedException();
        }

        public /*(EmployeeDTO?, */string?/*)*/ GetManagerByID(int id)
        {
            throw new NotImplementedException();
        }

        public /*(List<EmployeeDTO>?, */string?/*)*/ GetAllEmployeesManagedBy(int id)
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
