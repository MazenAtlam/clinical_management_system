using CCMS.BLL.Services.Abstraction;

namespace CCMS.BLL.Services.Implementation
{
    public class ManagerService : IManagerService
    {
        public async Task<string?> Create(/*EmployeeDTO emp, */string createdBy)
        {
            throw new NotImplementedException();
        }

        public async Task</*(List<EmployeeDTO>?, */string?/*)*/> GetAllManagers()
        {
            throw new NotImplementedException();
        }

        public async Task</*(EmployeeDTO?, */string?/*)*/> GetManagerByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task</*(List<EmployeeDTO>?, */string?/*)*/> GetAllEmployeesManagedBy(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> Update(/*EmployeeDTO emp, */string modifiedBy)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> Delete(int id, string modifiedBy)
        {
            throw new NotImplementedException();
        }
    }
}
