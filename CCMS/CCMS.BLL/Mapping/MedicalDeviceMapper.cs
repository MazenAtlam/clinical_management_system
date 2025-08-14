using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.DAL.Entities;
using Riok.Mapperly.Abstractions;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public partial class MedicalDeviceMapper
    {
        // Map MedicalDevice -> MedicalDeviceDTO
        public partial MedicalDeviceDTO ToResponseDto(MedicalDevice medicalDevice);
        public partial List<MedicalDeviceDTO> ToListResponseDto(List<MedicalDevice> medicalDevices);

        // Map MedicalDeviceDTO -> MedicalDevice
        public partial MedicalDevice ToEntity(MedicalDeviceDTO mdDeviceDTO);

    }
}
