using CCMS.BLL.ModelVM.Employee;
using CCMS.DAL.Entities;
using Riok.Mapperly.Abstractions;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public partial class EmployeeMapper
    {
        // Map Employee -> EmployeeDTO
        public partial EmployeeDTO ToResponseDto(Employee employee);
        public partial List<EmployeeDTO> ToListResponseDto(List<Employee> employees);

        // Map EmployeeDTO -> Employee
        public partial Employee ToEntity(EmployeeDTO emp);
    }
}
