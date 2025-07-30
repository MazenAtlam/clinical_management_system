namespace CCMS.BLL.Services.Abstraction
{
    public interface IDepartmentService
    {
        public string? Create(/*CreateDepartment dept, */string creatingUser);

        public /*(List<DepartmentDTO>, */string?/*)*/ GetAllDepartments();

        public /*(List<EmployeeDTO>, */string?/*)*/ GetAllEmployeesWorksOn(int deptID);

        public /*(List<RoomDTO>, */string?/*)*/ GetAllRoomsAt(int deptID);

        public /*(DepartmentDTO, */string?/*)*/ GetDepartmentByID(int deptID);

        public string? Update(/*DepartmentDTO dept, */string modifyingUser);

        public string? Delete(int deptID, string modifyingUser);
    }
}
