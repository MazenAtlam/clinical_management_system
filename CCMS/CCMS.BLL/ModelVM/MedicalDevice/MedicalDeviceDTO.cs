using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.MedicalDevice
{
    public class MedicalDeviceDTO
    {
        public string SerialNumber { get; set; }
        public string MDName { get; set; }
        public string Company { get; set; }
        public long ExpirationHours { get; set; }
        public MedicalDeviceStatus MDStatus { get; set; }
        public string CreatedBy { get; set; }
    }
}
