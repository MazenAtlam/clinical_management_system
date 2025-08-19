namespace CCMS.BLL.Services.Abstraction
{
    public interface IManagerService
    {
        public Task<string?> Create(/*EmployeeDTO emp, */string createdBy);

        public Task</*(List<EmployeeDTO>?, */string?/*)*/> GetAllManagers();

        public Task</*(EmployeeDTO?, */string?/*)*/> GetManagerByID(string id);

        public Task</*(List<EmployeeDTO>?, */string?/*)*/> GetAllEmployeesManagedBy(string id);

        public Task<string?> Update(/*EmployeeDTO emp, */string modifiedBy);

        public Task<string?> Delete(string id, string modifiedBy);
    }
}
