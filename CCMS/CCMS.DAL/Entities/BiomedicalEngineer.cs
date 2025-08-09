using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("BiomedicalEngineer", Schema = "ccms")]
    public class BiomedicalEngineer : Employee
    {
        public string name { get; private set; }
        public List<MedicalDevice>? medicalDevices { get; private set; }
        // IMPLEMENT CTOR
        public BiomedicalEngineer()
        {
            name = GetFullName();
        }
        public string GetFullName()
        {
            return $"{FName} {MidName} {LName}";
        }
        public void Edit(string name)
        {
            this.name = name;
        }
    }
}
