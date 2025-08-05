using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.DAL.Entities;
using Riok.Mapperly.Abstractions;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public static partial class MedicalDeviceMapper
    {
        // Map MedicalDevice -> MedicalDeviceDTO
        public static partial MedicalDeviceDTO ToResponseDto(MedicalDevice medicalDevice);
        public static partial List<MedicalDeviceDTO> ToListResponseDto(List<MedicalDevice> medicalDevices);

        // Map MedicalDeviceDTO -> MedicalDevice
        public static partial MedicalDevice ToEntity(MedicalDeviceDTO mdDeviceDTO);

    }
}
