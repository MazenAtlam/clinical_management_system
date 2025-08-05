using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [PrimaryKey("UID", "SerialNumber")]
    public class BiomedicalEngineer_MedicalDevice
    {
        [Required]
        [ForeignKey("BiomedicalEngineer")]
        public int UID { get; private set; }
        public BiomedicalEngineer BiomedicalEngineer { get; private set; }
        [Required]
        [MaxLength(100)]
        [ForeignKey("MedicalDevice")]
        public string SerialNumber { get; private set; }
        public MedicalDevice MedicalDevice { get; private set; }

        public BiomedicalEngineer_MedicalDevice() { }
        public BiomedicalEngineer_MedicalDevice(int bioEngID, string deviceSerialNum)
        {
            UID = bioEngID;
            SerialNumber = deviceSerialNum;
        }
    }
}
