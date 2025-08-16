using CCMS.BLL.ModelVM.Doctor;
using CCMS.DAL.Entities;
using Riok.Mapperly.Abstractions;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public partial class DoctorMapper
    {
        // Map Doctor -> DoctorDTO
        public partial DoctorDTO ToResponseDto(Doctor doctor);
        public partial List<DoctorDTO> ToListResponseDto(List<Doctor> doctors);

        // Map DoctorDTO -> Doctor
        public partial Doctor ToEntity(DoctorDTO docs);
    }
}
