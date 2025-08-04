using CCMS.BLL.ModelVM.Employee;
using CCMS.DAL.Entities;
using Riok.Mapperly.Abstractions;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public static partial class BiomedicalEngineerMapper
    {
        // Map BiomedicalEngineer -> EmployeeDTO
        public static partial EmployeeDTO ToResponseDto(BiomedicalEngineer biomedicalEngineer);
        public static partial List<EmployeeDTO> ToListResponseDto(List<BiomedicalEngineer> biomedicalEngineers);

        // Map EmployeeDTO -> BiomedicalEngineer
        public static partial BiomedicalEngineer ToEntity(EmployeeDTO mdDeviceDTO);
    }
}
