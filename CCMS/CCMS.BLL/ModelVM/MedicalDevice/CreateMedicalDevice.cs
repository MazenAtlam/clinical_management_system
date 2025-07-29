using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.MedicalDevice
{
    public class CreateMedicalDevice
    {
        public string serialNum { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public long expirationHours { get; set; }
        public MedicalDeviceStatus status { get; set; }
    }
}
