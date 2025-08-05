namespace CCMS.BLL.Services.Abstraction
{
    public interface IManagerService
    {
        public Task<string?> Create(/*EmployeeDTO emp, */string creatingUser);

        public Task</*(List<EmployeeDTO>?, */string?/*)*/> GetAllManagers();

        public Task</*(EmployeeDTO?, */string?/*)*/> GetManagerByID(int id);

        public Task</*(List<EmployeeDTO>?, */string?/*)*/> GetAllEmployeesManagedBy(int id);

        public Task<string?> Update(/*EmployeeDTO emp, */string modifyingUser);

        public Task<string?> Delete(int id, string modifyingUser);
    }
}
