namespace CCMS.BLL.Services.Abstraction
{
    public interface IDepartmentService
    {
        public Task<string?> Create(/*DepartmentDTO dept, */string creatingUser);

        public Task</*(List<DepartmentDTO>?, */string?/*)*/> GetAllDepartments();

        public Task</*(List<EmployeeDTO>?, */string?/*)*/> GetAllEmployeesWorksOn(int deptID);

        public Task</*(List<RoomDTO>?, */string?/*)*/> GetAllRoomsAt(int deptID);

        public Task</*(DepartmentDTO?, */string?/*)*/> GetDepartmentByID(int deptID);

        public Task<string?> Update(/*DepartmentDTO dept, */string modifyingUser);

        public Task<string?> Delete(int deptID, string modifyingUser);
    }
}
