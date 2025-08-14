using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("MedicalDevice", Schema="ccms")]
    public class MedicalDevice : Base
    {
        [Key]
        [MaxLength(100)]
        public string SerialNumber { get; private set; }
        [Required]
        [MaxLength (100)]
        public string MDName { get; private set; }
        [Required]
        [MaxLength (100)]
        public string Company { get; private set; }
        [Required]
        public long ExpirationHours { get; private set; }
        [Required]
        public MedicalDeviceStatus MDStatus { get; private set; }
        [ForeignKey("Room")]
        public string? rNumber { get; private set; }
        public Room? Room { get; private set; }
        public List<BiomedicalEngineer> BiomedicalEngineers { get; private set; } = new List<BiomedicalEngineer>();

        //public MedicalDevice() : base() { }
        public MedicalDevice(string serialNumber, string mdName, string company, long expirationHours, MedicalDeviceStatus mdStatus, string? rNumber, string createdBy)
            : base (createdBy)
            => SetAll(serialNumber, mdName, company, expirationHours, mdStatus, rNumber);

        private void SetAll(string serialNumber, string mdName, string company, long expirationHours, MedicalDeviceStatus mdStatus, string? rNumber)
        {
            SerialNumber = serialNumber;
            MDName = mdName;
            Company = company;
            ExpirationHours = expirationHours;
            MDStatus = mdStatus;
        }

        public void UpdateStatus(MedicalDeviceStatus newStatus, string modifiedBy)
        {
            MDStatus = newStatus;
            SaveModification(modifiedBy);
        }

        public void UpdateAll(string serialNumber, string mdName, string company, long expirationHours, MedicalDeviceStatus mdStatus, string? rNumber, string modifiedBy)
        {
            SetAll(serialNumber, mdName, company, expirationHours, mdStatus, rNumber);
            SaveModification(modifiedBy);
        }
    }
}
