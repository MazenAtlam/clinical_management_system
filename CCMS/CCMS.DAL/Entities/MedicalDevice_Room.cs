using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("MedicalDevice_Room", Schema="ccms")]
    public class MedicalDevice_Room : Base
    {
        [Key]
        [ForeignKey("MedicalDevice")]
        [MaxLength(100)]
        public string SerialNumber { get; private set; }
        public MedicalDevice MedicalDevice { get; private set; }
        [Required]
        [MaxLength(6)]
        [MinLength(6)]
        [ForeignKey("Room")]
        public string RNumber { get; private set; } // bbfrrr
        public Room Room { get; private set; }

        //public MedicalDevice_Room() : base() { }
        public MedicalDevice_Room(string serialNumber, string rNumber, string createdBy)
            : base(createdBy)
            => Set(serialNumber, rNumber);

        private void Set(string serialNumber, string rNumber)
        {
            SerialNumber = serialNumber;
            RNumber = rNumber;
        }

        public void Edit(string serialNumber, string rNumber, string modifiedBy)
        {
            Set(serialNumber, rNumber);
            SaveModification(modifiedBy);
        }
    }
}
