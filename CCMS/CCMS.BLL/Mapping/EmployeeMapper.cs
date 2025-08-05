using CCMS.BLL.ModelVM.Employee;
using CCMS.DAL.Entities;
using Riok.Mapperly.Abstractions;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public static partial class EmployeeMapper
    {
        // Map Employee -> EmployeeDTO
        public static partial EmployeeDTO ToResponseDto(Employee employee);
        public static partial List<EmployeeDTO> ToListResponseDto(List<Employee> employees);

        // Map EmployeeDTO -> Employee
        public static partial Employee ToEntity(EmployeeDTO emp);
    }
}
