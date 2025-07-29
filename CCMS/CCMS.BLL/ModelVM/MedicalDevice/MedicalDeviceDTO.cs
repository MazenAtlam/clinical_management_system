using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.MedicalDevice
{
    public class MedicalDeviceDTO
    {
        public string serialNum { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public long expirationHours { get; set; }
        public MedicalDeviceStatus status { get; set; }
        public string createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public string? latestModifiedBy { get; set; }
        public DateTime? latestModifiedOn { get; set; }
    }
}
