using CCMS.BLL.ModelVM.LabDoctor;
using CCMS.DAL.Entities;
using Riok.Mapperly.Abstractions;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public partial class LabDoctorMapper
    {
        // Map LabDoctor -> LabDoctorDTO
        public partial LabDoctorDTO ToResponseDto(LabDoctor labDoctor);
        public partial List<LabDoctorDTO> ToListResponseDto(List<LabDoctor> labDoctors);

        // Map LabDoctorDTO -> LabDoctor
        public partial LabDoctor ToEntity(LabDoctorDTO labDocs);
    }
}
