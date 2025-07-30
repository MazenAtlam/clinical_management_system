namespace CCMS.BLL.Services.Abstraction
{
    public interface IManagerService
    {
        public string? Create(/*CreateEmployee emp, */string creatingUser);

        public /*(List<EmployeeDTO>?, */string?/*)*/ GetAllManagers();

        public /*(EmployeeDTO?, */string?/*)*/ GetManagerByID(int id);

        public /*(List<EmployeeDTO>?, */string?/*)*/ GetAllEmployeesManagedBy(int id);

        public string? Update(/*EmployeeDTO emp, */string modifyingUser);

        public string? Delete(int id, string modifyingUser);
    }
}
