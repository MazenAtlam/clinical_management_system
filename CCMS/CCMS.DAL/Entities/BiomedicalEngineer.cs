namespace CCMS.DAL.Entities
{
    public class BiomedicalEngineer : Employee
    {
        public int id { get; private set; }
        public List<MedicalDevice>? medicalDevices { get; private set; }
    }
}
