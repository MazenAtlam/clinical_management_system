using CCMS.BLL.Services.Abstraction;

namespace CCMS.BLL.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        public async Task<string?> Create(/*DepartmentDTO dept, */string creatingUser)
        {
            throw new NotImplementedException();
        }

        public async Task</*(List<DepartmentDTO>?, */string?/*)*/> GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public async Task</*(List<EmployeeDTO>?, */string?/*)*/> GetAllEmployeesWorksOn(int deptID)
        {
            throw new NotImplementedException();
        }

        public async Task</*(List<RoomDTO>?, */string?/*)*/> GetAllRoomsAt(int deptID)
        {
            throw new NotImplementedException();
        }

        public async Task</*(DepartmentDTO?, */string?/*)*/> GetDepartmentByID(int deptID)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> Update(/*DepartmentDTO dept, */string modifyingUser)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> Delete(int deptID, string modifyingUser)
        {
            throw new NotImplementedException();
        }
    }
}
