using CCMS.BLL.Services.Abstraction;

namespace CCMS.BLL.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        public string? Create(/*CreateDepartment dept, */string creatingUser)
        {
            throw new NotImplementedException();
        }

        public /*(List<DepartmentDTO>?, */string?/*)*/ GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public /*(List<EmployeeDTO>?, */string?/*)*/ GetAllEmployeesWorksOn(int deptID)
        {
            throw new NotImplementedException();
        }

        public /*(List<RoomDTO>?, */string?/*)*/ GetAllRoomsAt(int deptID)
        {
            throw new NotImplementedException();
        }

        public /*(DepartmentDTO?, */string?/*)*/ GetDepartmentByID(int deptID)
        {
            throw new NotImplementedException();
        }

        public string? Update(/*DepartmentDTO dept, */string modifyingUser)
        {
            throw new NotImplementedException();
        }

        public string? Delete(int deptID, string modifyingUser)
        {
            throw new NotImplementedException();
        }
    }
}
