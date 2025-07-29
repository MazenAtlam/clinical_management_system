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

        public MedicalDevice() : base() { }
        public MedicalDevice(string serialNum, string mdName, string company, long expirationHours, MedicalDeviceStatus mdStatus, string creatingUser)
            : base(creatingUser)
            => SetAll(serialNum, mdName, company, expirationHours, mdStatus);

        private void SetAll(string serialNum, string mdName, string company, long expirationHours, MedicalDeviceStatus mdStatus)
        {
            SerialNumber = serialNum;
            MDName = mdName;
            Company = company;
            ExpirationHours = expirationHours;
            MDStatus = mdStatus;
        }

        private void SaveModification(string modifyingUser)
        {
            ModifiedBy = modifyingUser;
            ModifiedOn = DateTime.Now;
        }

        public void UpdateStatus(MedicalDeviceStatus newStatus, string modifyingUser)
        {
            MDStatus = newStatus;
            SaveModification(modifyingUser);
        }

        public void UpdateAll(string serialNum, string mdName, string company, long expirationHours, MedicalDeviceStatus mdStatus, string modifyingUser)
        {
            SetAll(serialNum, mdName, company, expirationHours, mdStatus);
            SaveModification(modifyingUser);
        }
    }
}
